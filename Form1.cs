using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LR4_WaySearch
{
    public partial class Form1 : Form
    {
        string[,] map = new string[40, 64];
        Point start = new Point(10, 10);
        Point finish = new Point(620, 380);
        bool[,] visited = new bool[40, 64];
        List<string> route = new List<string>();

        public Form1()
        {
            InitializeComponent();
            startXBox.Text = "10";
            startYBox.Text = "10";
            finishXBox.Text = "620";
            finishYBox.Text = "380";
            mapBox.Paint += mapBox_Paint; // Привязываем событие Paint
            mapBox.MouseUp -= mapBox_MouseUp;
        }

        //достпук к редактированию
        private void modeLab_CheckedChanged(object sender, EventArgs e)
        {
            if (modeLab.Checked == true) { mapBox.MouseUp += mapBox_MouseUp; }
            else { mapBox.MouseUp -= mapBox_MouseUp; }
        }

        //загрузка карты
        private void mapDownload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.DefaultExt = "txt";
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog.FileName;
                try
                {
                    string[] text = File.ReadAllLines(file);
                    mapForming(text);
                    mapBox.Invalidate();
                }
                catch (IOException)
                {
                    MessageBox.Show("Файл не может быть загружен");
                }
            }
            SaveWay.Enabled = false;
            mapSave.Enabled = true;
            setPosBtn.Enabled = true;
            bfs.Enabled = true;
        }

        //формирование карты
        private void mapForming(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    if (i == 0 || i == 39 || j == 0 || j == 63) { map[i, j] = "*"; }
                    else { map[i, j] = text[i][j].ToString(); }
                }
            }
        }

        //отрисовка карты
        private void mapBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            // Рисуем карту
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    Brush brush = map[i, j] == "#" ? new SolidBrush(Color.Red) :
                                  map[i, j] == "." || int.TryParse(map[i, j], out _) ? new SolidBrush(Color.White) :
                                  map[i, j] == "P" ? new SolidBrush(Color.DeepSkyBlue) :
                                  new SolidBrush(Color.Black);

                    gr.FillRectangle(brush, 10 * j, 10 * i, 10, 10);
                }
            }

            // старт
            if (map[start.Y / 10, start.X / 10] == "." || map[start.Y / 10, start.X / 10] == "P") { gr.FillEllipse(new SolidBrush(Color.Green), start.X, start.Y, 10, 10); }
            
            // финиш
            if (map[finish.Y / 10, finish.X / 10] == "." || map[finish.Y / 10, finish.X / 10] == "P") { gr.FillEllipse(new SolidBrush(Color.Blue), finish.X, finish.Y, 10, 10); }
        }

        //сохранение карты
        private void mapSave_Click(object sender, EventArgs e)
        {
            List<string> save_map = new List<string>();
            string line = "";
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 64; j++) { line += map[i, j]; }
                save_map.Add(line);
                line = "";
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            DialogResult result = saveFileDialog.ShowDialog(); // Show the dialog.
            string filename = saveFileDialog.FileName;
            System.IO.File.WriteAllLines(filename, save_map.ToArray());
            MessageBox.Show("Файл сохранён");
        }

        //изменение карты
        private void mapBox_MouseUp(object sender, MouseEventArgs e)
        {
            int x = int.Parse(e.X.ToString()) / 10;
            int y = int.Parse(e.Y.ToString()) / 10;
            if (x == start.X / 10 && y == start.Y / 10 || x == finish.X / 10 && y == finish.Y / 10) { }
            else {
                if (map[y, x] == "#") { map[y, x] = "."; }
                else if (map[y, x] == "." || int.TryParse(map[y, x], out _)) { map[y, x] = "#"; }
                mapBox.Invalidate();
            }
        }

        //установка старта и финиша
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

        //точечное обновление карты
        private void UpdateMap(int x, int y, Color color)
        {
            using (Graphics gr = mapBox.CreateGraphics())
            {
                gr.FillRectangle(new SolidBrush(color), 10 * x, 10 * y, 10, 10);
            }
        }

        //поиск пути
        private void bfs_Click(object sender, EventArgs e)
        {
            setPosBtn.Enabled = false;
            mapDownload.Enabled = false;
            bfs.Enabled = false;

            // Инициализация
            Queue<(int, int)> queue = new Queue<(int, int)>();
            visited = new bool[40, 64];
            (int, int)[,] parent = new (int, int)[40, 64];
            int[,] commands = new int[40, 64];

            // Задаем стартовые значения
            queue.Enqueue((start.X / 10, start.Y / 10));
            visited[start.Y / 10, start.X / 10] = true;

            // Направления для перемещения (вверх, вниз, влево, вправо)
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { -1, 0, 1, 0 };

            // BFS-цикл
            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();

                UpdateMap(x, y, Color.LightGray);
                System.Threading.Thread.Sleep(20);

                // Если достигли финиша, останавливаем поиск
                if (x == finish.X / 10 && y == finish.Y / 10)
                {
                    HighlightPath(parent, commands, start.X / 10, start.Y / 10, finish.X / 10, finish.Y / 10);
                    return;
                }

                // Проверяем соседей
                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    // Проверяем, что сосед внутри карты, не препятствие и не посещен
                    if (nx >= 0 && nx < 64 && ny >= 0 && ny < 40 &&
                        (map[ny, nx] == "." || map[ny, nx] == "w") && !visited[ny, nx])
                    {
                        queue.Enqueue((nx, ny));
                        visited[ny, nx] = true;
                        parent[ny, nx] = (x, y);
                        commands[ny, nx] = (i + 1);
                    }
                }
            }
            MessageBox.Show("Путь не найден!");
            mapDownload.Enabled = true;
        }

        // Подсветка пути на карте
        private void HighlightPath((int, int)[,] parent, int[,] commands, int startX, int startY, int finishX, int finishY)
        {
            int x = finishX, y = finishY;
            while ((x, y) != (startX, startY))
            {
                map[y, x] = "P"; // Обозначение пути
                (x, y) = parent[y, x];
                route.Add(commands[y, x].ToString() + "; " + x.ToString() + "; " + y.ToString());
            }
            map[startX, startY] = "P";
            mapBox.Invalidate();
            mapDownload.Enabled = true;
            SaveWay.Enabled = true;
        }

        //отрисовка всех возможных путей
        private void showAllWays_CheckedChanged(object sender, EventArgs e)
        {
            if (showAllWays.Checked == true)
            {
                for (int i = 0; i < 40; i++)
                {
                    for (int j = 0;  j < 64; j++)
                    {
                        if (visited[i, j] && map[i, j] != "P")
                        {
                            UpdateMap(j, i, Color.LightGray);
                        }
                    }
                }
            }
            else
            {
                mapBox.Invalidate();
            }
        }

        //сохранение маршрута
        private void SaveWay_Click(object sender, EventArgs e)
        {
            route.Reverse();
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Сохранить маршрут в CSV";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllLines(saveFileDialog.FileName, route);
                        Console.WriteLine("Маршрут успешно сохранён в файл: " + saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при сохранении файла: " + ex.Message);
                    }
                }
            }
        }
    }
}
