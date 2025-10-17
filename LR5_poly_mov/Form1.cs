using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace LR5_poly_mov
{
    public partial class Form1 : Form
    {
        // Хранение данных полигонов
        private List<List<Point>> polygons = new List<List<Point>>(); //полигоны
        private List<Point> nodes = new List<Point>(); //узлы
        private List<List<Point>> edges = new List<List<Point>>(); //ребра
        private List<List<Point>> good_edges = new List<List<Point>>(); //подходят по длине
        private List<List<Point>> perfect_edges = new List<List<Point>>(); // подходят и по длине и не пересекают полигоны
        private List<Point> final_route = new List<Point>(); //final_route
        Point start = new Point(20, 360);
        Point finish = new Point(610, 20);
        bool isStart = false;
        bool isFinish = false;
        Bitmap mapBitmap;
        Bitmap edgesBitmap;
        Bitmap goodEdgesBitmap;
        Bitmap perfectEdgesBitmap;
        Bitmap wayBitmap;
        bool isShowEdges = false;
        bool isShowGoodEdges = false;
        bool isShowPerfectEdges = false;
        bool isShowWay = false;

        public Form1()
        {
            InitializeComponent();
            startXBox.Text = "20";
            startYBox.Text = "360";
            finishXBox.Text = "610";
            finishYBox.Text = "20";
            maxD.Value = 400;
            mapBitmap = new Bitmap(mapBox.Width, mapBox.Height);
            edgesBitmap = new Bitmap(mapBox.Width, mapBox.Height);
            goodEdgesBitmap = new Bitmap(mapBox.Width, mapBox.Height);
            perfectEdgesBitmap = new Bitmap(mapBox.Width, mapBox.Height);
            wayBitmap = new Bitmap(mapBox.Width, mapBox.Height);
            mapBox.Paint += mapBox_Paint;

            wayCheck.Checked = false;
            showAllEdges.Checked = false;
            showGoodEdges.Checked = false;
            showPerfectEdges.Checked = false;
            orangeBox.Enabled = false;
        }

        // Загрузка карты
        private void mapDownload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.csv)|*.csv";
            openFileDialog.DefaultExt = "csv";
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog.FileName;
                try
                {
                    string[] text = File.ReadAllLines(file);
                    // Загрузка и парсинг файла
                    polygons.Clear();
                    polygons = LoadPolygonsFromCsv(file);
                    showListBox();
                    mapBox.Invalidate();
                    setPosBtn.Enabled = true;
                    bfs.Enabled = true;

                    wayCheck.Checked = false;
                    showAllEdges.Checked = false;
                    showGoodEdges.Checked = false;
                    showPerfectEdges.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Выберите другой лабиринт");
                }
            }
        }

        // Загрузка и парсинг файла
        private List<List<Point>> LoadPolygonsFromCsv(string filePath)
        {
            var loadedPolygons = new List<List<Point>>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                // Пропускаем пустые строки
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Разделяем координаты
                var points = line.Split(';')
                                 .Select(coord =>
                                 {
                                     var parts = coord.Split(',');
                                     return new Point(int.Parse(parts[0]), int.Parse(parts[1]));
                                 })
                                 .ToList();

                loadedPolygons.Add(points);
            }

            return loadedPolygons;
        }

        // Отображение в ListBox
        private void showListBox()
        {
            foreach (var polygon in polygons)
            {
                mapListBox.Items.Add(string.Join(", ", polygon.Select(p => $"({p.X}, {p.Y})")));
            }
        }

        private void mapBox_Paint(object sender, PaintEventArgs e)
        {
            if (polygons == null || polygons.Count == 0)
                return;

            // Отрисовка карты
            DrawMap();

            if (isShowEdges) DrawEdges(); // Отрисовка рёбер
            else if (isShowGoodEdges) DrawGoodEdges(); // Отрисовка подходящих рёбер
            else if (isShowPerfectEdges) DrawPerfectEdges(); // Отрисовка идеальных рёбер
            else if (isShowWay) DrawWay(); // Отрисовка пути
            UpdateMapDisplay();
        }

        // Метод для отрисовки карты
        private void DrawMap()
        {
            using (Graphics g = Graphics.FromImage(mapBitmap))
            {
                // Закрашиваем фон белым
                g.Clear(Color.White);
                
                foreach (var polygon in polygons)
                {
                    Brush obstacleBrush = new SolidBrush(Color.Gray);
                    // Масштабируем координаты
                    var scaledPolygon = polygon.Select(p => new Point(p.X * 40, mapBox.Height - p.Y * 40)).ToArray();

                    // Рисуем полигон
                    g.FillPolygon(obstacleBrush, scaledPolygon);
                }

                // Рисуем начальную и конечную точки
                if (checkOnCross(start.X, start.Y))
                    g.FillEllipse(new SolidBrush(Color.Green), start.X - 16, start.Y - 16, 32, 32);

                if (checkOnCross(finish.X, finish.Y))
                    g.FillEllipse(new SolidBrush(Color.Blue), finish.X - 16, finish.Y - 16, 32, 32);
            }
        }

        // Метод для отрисовки рёбер
        private void DrawEdges()
        {
            using (Graphics edgesGraphics = Graphics.FromImage(edgesBitmap))
            {
                edgesGraphics.Clear(Color.Transparent); // Очищаем битмап для рёбер

                if (edges != null)
                {
                    using (Pen edgePen = new Pen(Color.LightBlue))
                    {
                        foreach (var edge in edges)
                        {
                            edgesGraphics.DrawLine(edgePen, edge[0], edge[1]);
                        }
                    }
                }
            }
        }

        // Метод для отрисовки подходящих рёбер
        private void DrawGoodEdges()
        {
            using (Graphics goodEdgesGraphics = Graphics.FromImage(goodEdgesBitmap))
            {
                goodEdgesGraphics.Clear(Color.Transparent); // Очищаем битмап для рёбер

                if (good_edges != null)
                {
                    using (Pen edgePen = new Pen(Color.LightGreen))
                    {
                        foreach (var edge in good_edges)
                        {
                            goodEdgesGraphics.DrawLine(edgePen, edge[0], edge[1]);
                        }
                    }
                }
            }
        }

        // Метод для отрисовки идеальных рёбер
        private void DrawPerfectEdges()
        {
            using (Graphics perectEdgesGraphics = Graphics.FromImage(perfectEdgesBitmap))
            {
                perectEdgesGraphics.Clear(Color.Transparent); // Очищаем битмап для рёбер

                if (perfect_edges != null)
                {
                    using (Pen edgePen = new Pen(Color.LightCoral))
                    {
                        foreach (var edge in perfect_edges)
                        {
                            perectEdgesGraphics.DrawLine(edgePen, edge[0], edge[1]);
                        }
                    }
                }
            }
        }

        private void DrawWay()
        {
            if(final_route != null)
            {
                using (Graphics wayGraphics = Graphics.FromImage(wayBitmap))
                {
                    wayGraphics.Clear(Color.Transparent); // Очищаем битмап для рёбер
                    foreach (var polygon in polygons)
                    {
                        Brush obstacleBrush = new SolidBrush(Color.Gray);
                        // Масштабируем координаты
                        var scaledPolygon = polygon.Select(p => new Point(p.X * 40, mapBox.Height - p.Y * 40)).ToArray();

                        if (orangeBox.Checked)
                        {
                            foreach (Point point in scaledPolygon)
                            {
                                foreach (Point p in final_route)
                                {
                                    if (point == p) obstacleBrush = new SolidBrush(Color.Orange);
                                }
                            }
                        }
                        // Рисуем полигон
                        wayGraphics.FillPolygon(obstacleBrush, scaledPolygon);
                    }
                    using (Pen pathPen = new Pen(Color.Red, 2))
                    {
                        for (int i = 0; i < final_route.Count - 1; i++)
                        {
                            wayGraphics.DrawLine(pathPen, final_route[i], final_route[i + 1]);
                        }
                    }
                }
            }
        }

        // Метод для обновления отображаемого изображения
        private void UpdateMapDisplay()
        {
            if (isShowWay)
            {
                // Объединяем mapBitmap и WayBitmap
                using (Bitmap combinedBitmap = new Bitmap(mapBitmap.Width, mapBitmap.Height))
                {
                    using (Graphics g = Graphics.FromImage(combinedBitmap))
                    {
                        g.DrawImage(mapBitmap, 0, 0); // Сначала основной битмап
                        g.DrawImage(wayBitmap, 0, 0); // Затем битмап с рёбрами
                    }

                    mapBox.Image = (Bitmap)combinedBitmap.Clone(); // Устанавливаем объединённый битмап
                }
            }
            else if (isShowEdges)
            {
                // Объединяем mapBitmap и edgesBitmap
                using (Bitmap combinedBitmap = new Bitmap(mapBitmap.Width, mapBitmap.Height))
                {
                    using (Graphics g = Graphics.FromImage(combinedBitmap))
                    {
                        g.DrawImage(mapBitmap, 0, 0); // Сначала основной битмап
                        g.DrawImage(edgesBitmap, 0, 0); // Затем битмап с рёбрами
                    }

                    mapBox.Image = (Bitmap)combinedBitmap.Clone(); // Устанавливаем объединённый битмап
                }
            }
            else if (isShowGoodEdges)
            {
                // Объединяем mapBitmap и edgesBitmap
                using (Bitmap combinedBitmap = new Bitmap(mapBitmap.Width, mapBitmap.Height))
                {
                    using (Graphics g = Graphics.FromImage(combinedBitmap))
                    {
                        g.DrawImage(mapBitmap, 0, 0); // Сначала основной битмап
                        g.DrawImage(goodEdgesBitmap, 0, 0); // Затем битмап с рёбрами
                    }

                    mapBox.Image = (Bitmap)combinedBitmap.Clone(); // Устанавливаем объединённый битмап
                }
            }
            else if (isShowPerfectEdges)
            {
                // Объединяем mapBitmap и edgesBitmap
                using (Bitmap combinedBitmap = new Bitmap(mapBitmap.Width, mapBitmap.Height))
                {
                    using (Graphics g = Graphics.FromImage(combinedBitmap))
                    {
                        g.DrawImage(mapBitmap, 0, 0); // Сначала основной битмап
                        g.DrawImage(perfectEdgesBitmap, 0, 0); // Затем битмап с рёбрами
                    }

                    mapBox.Image = (Bitmap)combinedBitmap.Clone(); // Устанавливаем объединённый битмап
                }
            }
            else
            {
                mapBox.Image = mapBitmap; // Показываем только карту
            }
        }


        private bool checkOnCross(int x, int y)
        {
            x -= 16; y -= 16;
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    Color color = mapBitmap.GetPixel(x + i, y + j);
                    if (color.R != 255 && Math.Pow(16 - i, 2) + Math.Pow(16 - j, 2) < 256) return false;
                }
            }
            return true;
        }

        private void setPosBtn_Click(object sender, EventArgs e)
        {
            try
            {
                start = new Point(int.Parse(startXBox.Text) / 10 * 10, int.Parse(startYBox.Text) / 10 * 10);
                finish = new Point(int.Parse(finishXBox.Text) / 10 * 10, int.Parse(finishYBox.Text) / 10 * 10);
                mapBox.Invalidate();
            }
            catch
            {
                MessageBox.Show("Старт/Финиш введен неверно!");
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            mapBox.MouseUp += mapBox_MouseUp;
            isStart = true;
            isFinish = false;
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            mapBox.MouseUp += mapBox_MouseUp;
            isFinish = true;
            isStart = false;
        }

        private void mapBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isStart)
            {
                start.X = int.Parse(e.X.ToString());
                start.Y = int.Parse(e.Y.ToString());
                mapBox.Invalidate();
                isStart = false;
            }
            else if (isFinish)
            {
                finish.X = int.Parse(e.X.ToString());
                finish.Y = int.Parse(e.Y.ToString());
                mapBox.Invalidate();
                isFinish = false;
            }
        }

        private void bfs_Click(object sender, EventArgs e)
        {
            nodes.Clear();
            edges.Clear();
            good_edges.Clear();
            perfect_edges.Clear();
            final_route.Clear();

            foreach (var polygon in polygons)
            {
                foreach (Point point in polygon)
                {
                    nodes.Add(new Point(point.X * 40, mapBox.Height - point.Y * 40));
                }
            }
            nodes.Add(start);
            nodes.Add(finish);

            for (int i = 0; i < nodes.Count - 1; i++)
            {
                for (int j = i + 1; j < nodes.Count; j++)
                {
                    List<Point> edge = new List<Point>();
                    edge.Add(nodes[i]); edge.Add(nodes[j]);
                    edges.Add(edge);
                }
            }

            foreach (var edge in edges)
            {
                if (Math.Sqrt(Math.Pow(edge[1].X - edge[0].X, 2) + Math.Pow(edge[1].Y - edge[0].Y, 2)) < (double) maxD.Value)
                {
                    good_edges.Add(edge);
                }
            }

            foreach (var edge in good_edges)
            {
                if(DoesWayFree(edge[0], edge[1])) { perfect_edges.Add(edge); }
            }

            StartPathFinding();

            mapBox.Invalidate();
        }

        private bool DoesWayFree(Point start, Point end)
        {
            // Функция для проверки, находится ли точка внутри границ изображения
            bool IsPointInBounds(int x1, int y1)
            {
                return x1 >= 0 && x1 < mapBitmap.Width && y1 >= 0 && y1 < mapBitmap.Height;
            }

            // Используем алгоритм Брезенхэма для прохода по точкам линии
            int dx = Math.Abs(end.X - start.X);
            int dy = Math.Abs(end.Y - start.Y);
            int sx = start.X < end.X ? 1 : -1;
            int sy = start.Y < end.Y ? 1 : -1;
            int err = dx - dy;

            int x = start.X;
            int y = start.Y;

            int intersections = 0;

            while (true)
            {
                // Проверяем, что точка находится в границах изображения
                if (IsPointInBounds(x, y))
                {
                    // Если цвет пикселя серый, путь занят
                    if (mapBitmap.GetPixel(x, y).R == 128 && mapBitmap.GetPixel(x, y).G == 128 && mapBitmap.GetPixel(x, y).B == 128)
                        intersections++;
                }
                else
                {
                    // Если точка вне границ, считаем путь заблокированным
                    return false;
                }

                // Если достигли конечной точки, выходим из цикла
                if (x == end.X && y == end.Y)
                    break;

                if (intersections > 3) return false;

                // Расчёт ошибки и корректировка координат
                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y += sy;
                }
            }

            // Если все точки линии свободны, путь свободен
            return true;
        }

        // Метод для поиска кратчайшего пути
        private List<Point> FindPath()
        {
            // Очередь для хранения текущих путей
            Queue<List<Point>> queue = new Queue<List<Point>>();

            // Список для хранения кратчайшего пути
            List<Point> shortestPath = null;

            // Добавляем стартовый узел в очередь
            queue.Enqueue(new List<Point> { start });

            // Пока очередь не пуста
            while (queue.Count > 0)
            {
                // Извлекаем текущий путь
                var currentPath = queue.Dequeue();
                var currentNode = currentPath.Last();

                // Если достигнут конечный узел
                if (currentNode == finish)
                {
                    if (shortestPath == null || CalculatePathLength(currentPath) < CalculatePathLength(shortestPath))
                    {
                        shortestPath = new List<Point>(currentPath);
                    }
                    continue;
                }

                // Обрабатываем соседей текущего узла
                foreach (var edge in perfect_edges)
                {
                    // Определяем соседа текущего узла
                    Point neighbor = Point.Empty;

                    if (edge[0] == currentNode)
                        neighbor = edge[1];
                    else if (edge[1] == currentNode)
                        neighbor = edge[0];

                    // Если сосед корректный и не входит в текущий путь
                    if (!neighbor.IsEmpty && !currentPath.Contains(neighbor))
                    {
                        // Создаём новый путь, добавляем соседа и помещаем его в очередь
                        var newPath = new List<Point>(currentPath) { neighbor };

                        // Проверяем, если путь перспективный (меньше уже найденного кратчайшего пути)
                        if (shortestPath == null || CalculatePathLength(newPath) < CalculatePathLength(shortestPath))
                        {
                            queue.Enqueue(newPath);
                        }
                    }
                }
            }

            // Возвращаем кратчайший путь или пустой список
            return shortestPath ?? null;
        }

        // Метод для вычисления длины пути
        private int CalculatePathLength(List<Point> path)
        {
            int totalLength = 0;

            for (int i = 0; i < path.Count - 1; i++)
            {
                var pointA = path[i];
                var pointB = path[i + 1];
                totalLength += (int)Math.Sqrt(
                    Math.Pow(pointB.X - pointA.X, 2) + Math.Pow(pointB.Y - pointA.Y, 2));
            }

            return totalLength;
        }

        // Метод для визуализации пути
        private void VisualizePath(List<Point> path)
        {
            if (path == null || path.Count == 0)
            {
                return;
            }

            final_route = path;
        }

        // Пример вызова поиска пути и визуализации
        private void StartPathFinding()
        {
            var path = FindPath();
            VisualizePath(path);
        }


        private void showAllEdges_CheckedChanged(object sender, EventArgs e)
        {
            if (showAllEdges.Checked)
            {
                isShowEdges = true;
                showGoodEdges.Checked = false;
                showPerfectEdges.Checked = false;
                wayCheck.Checked = false;
            }
            else isShowEdges = false;
        }

        private void showGoodEdges_CheckedChanged(object sender, EventArgs e)
        {
            if (showGoodEdges.Checked)
            {
                isShowGoodEdges = true;
                showAllEdges.Checked = false;
                showPerfectEdges.Checked = false;
                wayCheck.Checked = false;
            }
            else isShowGoodEdges = false;
        }

        private void showPerfectEdges_CheckedChanged(object sender, EventArgs e)
        {
            if (showPerfectEdges.Checked)
            {
                isShowPerfectEdges = true;
                showGoodEdges.Checked = false;
                showAllEdges.Checked = false;
                wayCheck.Checked = false;
            }
            else isShowPerfectEdges = false;
        }

        private void wayCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (wayCheck.Checked)
            {
                isShowWay = true;
                showAllEdges.Checked = false;
                showGoodEdges.Checked = false;
                showPerfectEdges.Checked = false;
                orangeBox.Enabled = true;
            }
            else
            {
                isShowWay = false;
                orangeBox.Enabled = false;
            }
        }

        private void orangeBox_CheckedChanged(object sender, EventArgs e)
        {
            mapBox.Invalidate();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (final_route == null || final_route.Count == 0)
            {
                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                var route = SaveRoute();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Сохранить маршрут в CSV";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Записываем заголовок
                        File.WriteAllLines(saveFileDialog.FileName, route);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private List<String> SaveRoute()
        {
            List<String> routes = new List<String>();
            routes.Add("Номер точки,Угол,Пробег,X,Y,Курс");
            int absoluteAngle = 0;

            int currentCourse = 0; // Изначальный курс - на север (0 градусов)

            for (int i = 0; i < final_route.Count; i++)
            {
                var currentPoint = final_route[i];
                int angle = 0;
                int distance = 0;

                // Если это не последняя точка, вычисляем угол и расстояние до следующей точки
                if (i < final_route.Count - 1)
                {
                    var nextPoint = final_route[i + 1];

                    // Разница координат
                    int deltaX = nextPoint.X - currentPoint.X;
                    int deltaY = nextPoint.Y - currentPoint.Y;

                    // Расстояние между точками
                    distance = (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                    // Абсолютный угол до следующей точки относительно оси X
                    absoluteAngle = (int)(Math.Atan2(-deltaY, deltaX) * 180 / Math.PI); // "-" для инверсии оси Y
                    absoluteAngle = (absoluteAngle + 360) % 360; // Приведение к диапазону [0, 360)

                    // Угол поворота по часовой стрелке от текущего курса до нового
                    angle = (absoluteAngle - currentCourse) % 360; // Приведение к диапазону [0, 360)
                }

                // Записываем данные в список
                routes.Add($"{i + 1},{angle},{distance},{currentPoint.X},{currentPoint.Y},{currentCourse}");

                // Обновляем текущий курс
                currentCourse = absoluteAngle;
            }

            return routes;
        }

    }
}