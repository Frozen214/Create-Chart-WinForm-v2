using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

  private void button1_Click(object sender, EventArgs e)
        {
            CreateChart2(товарDataGridView, "testName");
        }
private void CreateChart2(DataGridView grid, string nameTitle)
        {
            try
            {
                chartOI.Series["Series1"].Points.Clear();

                for (int i = 0; i < grid.RowCount; i++)
                {
                    var name = grid.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var value = grid.Rows[i].Cells[0].Value?.ToString() ?? "";
                    chartOI.Series["Series1"].Points.AddXY(name, value);
                }
                chartOI.Titles.Clear();
                chartOI.Titles.Add(nameTitle);

                chartOI.ChartAreas[0].AxisX.Title = grid.Columns[1].HeaderText;
                chartOI.ChartAreas[0].AxisY.Title = grid.Columns[0].HeaderText;

                MessageBox.Show("График сформирован", "Успех");
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ошибка: Недостаточно столбцов в DataGridView", "Ошибка");
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: недопустимые данные в DataGridView", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }