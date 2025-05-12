using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDdataBaseTraining
{
    public partial class Form1 : Form
    {

        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AppDB;Integrated Security=True"; // создал строку подключения к БД 

        private int currentId = -1; //если запись новая будет использоваться для добавления новой записи инче для редактирования а в качестве аргумента данных будет установлен id редактируемой записи

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData() // реализация метода загрузки данных 
        {
            try
            {

                flowLayoutPanel1.Controls.Clear();
               

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand(@"SELECT p.*, c.Name AS CategoryName, s.Name as SupplierName FROM Products p LEFT JOIN Categories c ON p.CategoryId = c.CategoryId LEFT JOIN Suppliers s ON p.SupplierId = s.SupplierId", conn); //!!!!
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Price = (decimal)reader["Price"],
                            Quantity = (int)reader["Quantity"],
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            ExpireDate = reader["ExpireDate"] != DBNull.Value ?
                            (DateTime?)reader["ExpireDate"] : null,
                            CategoryId = (int)reader["CategoryId"],
                            CategoryName = reader["CategoryName"].ToString(),
                            SupplierId = (int)reader["SupplierId"],
                            SupplierName = reader["SupplierName"].ToString()
                        };

                        CreatePanel(product);
                    }
                    reader.Close();

                    LoadDataCategories(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"В момент выполнения программы произошла ошибка: {ex.Message}");
                
            }
            
        }


        private void LoadDataCategories(SqlConnection connection)
        {
            try
            {
                flowLayoutPanel2.Controls.Clear();

                var cmdCategories = new SqlCommand("SELECT * FROM Categories", connection);
                var readerCategories = cmdCategories.ExecuteReader();

                while (readerCategories.Read())
                {
                    var categories = new Categories
                    {
                        CategoryId = (int)readerCategories["CategoryId"],
                        Name = readerCategories["Name"].ToString(),
                        Description = readerCategories["Description"].ToString()
                    };

                    CreatePanelCategories(categories);
                }
                readerCategories.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show($"В момент выполнения программы произошла ошибка: {ex.Message}");
            }
        }

        private void CreatePanelCategories(Categories categories)
        {
            try
            {
                var panelCategories = new Panel
                {
                    Width = 300,
                    Height = 100,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.Fixed3D,
                    Margin = new Padding(10)


                };
                var lblCategoriesId = new Label
                {
                    Text = $"Идентификатор: {categories.CategoryId}",
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                var lblCategoriesName = new Label
                {
                    Text = $"Название: {categories.Name}",
                    Location = new Point(10, 30),
                    AutoSize = true
                };

                var lblCategoriesDescription = new Label
                {
                    Text = $"Описание: {categories.Description}",
                    Location = new Point(10, 50),
                    AutoSize = true
                };

                panelCategories.Controls.AddRange(new Control[] {lblCategoriesId, lblCategoriesName, lblCategoriesDescription});

                flowLayoutPanel2.Controls.Add(panelCategories);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"В момент выполнения программы произошла ошибка: {ex.Message}");
            }
        }






        private void CreatePanel(Product products)
        {
            try
            {
                var panel = new Panel
                {
                    Width = 400,
                    Height = 150,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                var lblName = new Label
                {
                    Text = products.Name,
                    Location = new Point(10, 10),
                    AutoSize = true
                };
                var lblPrice = new Label
                {
                    Text = $"Цена: {products.Price:C}",
                    Location = new Point(10, 30),
                    AutoSize = true
                };
                var lblQuantity = new Label
                {
                    Text = $"Количество: {products.Quantity}",
                    Location = new Point(10, 50),
                    AutoSize = true
                };

                var lblCreatedDate = new Label
                {
                    Text = $"Дата создания: {products.CreatedDate:d}",
                    Location = new Point(10, 70),
                    AutoSize = true
                };

                var lblExpireDate = new Label
                {
                    Text = products.ExpireDate.HasValue ? $"Годен до: {products.ExpireDate:d}" : "Срок не указан",
                    Location = new Point(10, 90),
                    AutoSize = true
                };

                var lblCategory = new Label
                {
                    Text = $"Категория: {products.CategoryName}",
                    Location = new Point(10, 110),
                    AutoSize = true
                };

                var lblSuppliers = new Label
                {
                    Text = $"Поставщик: {products.SupplierName}",
                    Location = new Point(10, 130),
                    AutoSize = true

                };

                var btnEdit = new Button
                {
                    Text = "Изменить",
                    Location = new Point(150, 10),
                    Tag = products.Id
                };
                btnEdit.Click += btnUpdate_Click;
                var btnDelete = new Button
                {
                    Text = "Delete",
                    Location = new Point(150, 40),
                    Tag = products.Id
                };

                btnDelete.Click += btnDelete_Click;

                panel.Controls.AddRange(new Control[] { lblName, lblPrice, lblQuantity, lblCreatedDate, lblExpireDate,lblCategory,lblSuppliers, btnEdit, btnDelete });

                flowLayoutPanel1.Controls.Add(panel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"В момент выполнения программы произошла ошибка: {ex.Message}");
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            currentId = (int)btn.Tag;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Products WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", currentId);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    txtPrice.Text = reader["Price"].ToString();
                    txtQuant.Text = reader["Quantity"].ToString();
                    txtCategoryId.Text = reader["CategoryId"].ToString();
                    txtSupplier.Text = reader["SupplierId"].ToString();
                    dtpCreatedDate.Value = (DateTime)reader["CreatedDate"];

                    if (reader["ExpireDate"] != DBNull.Value)
                    {
                        dtpExpireDate.Checked = true;
                        dtpExpireDate.Value = (DateTime)reader["ExpireDate"];
                    }
                    else
                    {
                        dtpExpireDate.Checked = false;
                    }


                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            var btn = (Button)sender;
            var id = (int)btn.Tag;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Products WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using(var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    if(currentId == -1)
                    {
                        cmd = new SqlCommand("INSERT INTO Products (Name, Price, Quantity, CreatedDate, ExpireDate, CategoryId, SupplierId) VALUES (@Name, @Price, @Quantity,@CreatedDate, @ExpireDate, @CategoryId, @SupplierId)", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("UPDATE Products SET Name = @Name , Price = @Price, Quantity = @Quantity, CreatedDate = @CreatedDate, ExpireDate = @ExpireDate, CategoryId = @CategoryId, SupplierId = @SupplierId WHERE Id = @Id", conn);
                        cmd.Parameters.AddWithValue("@Id", currentId);
                    }

                    //cmd.Parameters.AddWithValue("@Id", currentId);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuant.Text));
                    cmd.Parameters.AddWithValue("@CreatedDate", dtpCreatedDate.Value);
                    cmd.Parameters.AddWithValue("@ExpireDate", dtpExpireDate.Checked ? (object)dtpExpireDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryId", int.Parse(txtCategoryId.Text));
                    cmd.Parameters.AddWithValue("@SupplierId", int.Parse(txtSupplier.Text));
                    
                    cmd.ExecuteNonQuery();
                    ClearFields();
                    LoadData();
                }
                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"В момент выполнения программы произошла ошибка: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            currentId = -1;
            txtName.Clear();
            txtPrice.Clear();
            txtQuant.Clear();
            txtCategoryId.Clear();
            txtSupplier.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"В момент выполнения программы произошла ошибка: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtCategoryId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpExpireDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpCreatedDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtQuant_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
