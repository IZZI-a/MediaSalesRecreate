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
    public partial class Form2 : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AppDB;Integrated Security=True";
        private int currentId = -1;

        public Form2()
        {
            InitializeComponent();
            LoadDataSuppliers();
        }

        private void LoadDataSuppliers()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    var cmdLoad = new SqlCommand("SELECT * FROM Suppliers", conn);
                    var reader = cmdLoad.ExecuteReader();

                    while (reader.Read())
                    {
                        var suppliers = new Supliers
                        {
                            SupplierId = (int)reader["SupplierId"],
                            Name = reader["Name"].ToString(),
                            ContactPerson = reader["ContactPerson"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"].ToString(),
                            IsActive = (bool)reader["IsActive"],
                        };
                        CreatePanelSupplier(suppliers);
                    }
                    reader.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Возникла непредвиденная ошибка: {ex.Message}");
            }
        }


        private void CreatePanelSupplier(Supliers supliers)
        {

            try
            {
                

                var panelSupplier = new Panel
                {
                    Width = 450,
                    Height = 200,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };


                var lblSuppliersId = new Label
                {
                    Text = $"{supliers.SupplierId}",
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                var lblSuppliersName = new Label
                {
                    Text = $"{supliers.Name}",
                    Location = new Point(10, 30),
                    AutoSize = true
                };
                
                var lblSuppliersContacts = new Label
                {
                    Text = $"{supliers.ContactPerson}",
                    Location = new Point(10, 50),
                    AutoSize = true
                };
                var lblSuppliersEmail = new Label
                {
                    Text = $"{supliers.Email}",
                    Location = new Point(10, 70),
                    AutoSize = true
                };
                var lblSuppliersPhone = new Label
                {
                    Text = $"{supliers.Phone}",
                    Location = new Point(10, 90),
                    AutoSize = true
                };
           
                var lblSuppliersAdress = new Label
                {
                    Text = $"{supliers.Address}",
                    Location = new Point(10, 110),
                    AutoSize = true
                };

                var btnToggleActive = new Button
                {
                    Text = supliers.IsActive ? "Active" : "Deactive",
                    Tag = supliers.SupplierId,
                    Location = new Point(300, 10)
                };

                btnToggleActive.Click += (s, e) => ToggleSupliersStatus((int)((Button)s).Tag);


                var btnEdit = new Button
                {
                    Text = "Edit",
                    Tag = supliers.SupplierId,
                    Location = new Point(300, 40)
                };

                btnEdit.Click += BtnEdit_Click;

                var btnDelete = new Button
                {
                    Text = "Delete",
                    Tag = supliers.SupplierId,
                    Location = new Point(300, 70)
                };

                btnDelete.Click += BtnDelete_Click;

                panelSupplier.Controls.AddRange(new Control[] { lblSuppliersId, lblSuppliersName, lblSuppliersEmail, lblSuppliersPhone, lblSuppliersContacts, lblSuppliersAdress, btnToggleActive, btnEdit, btnDelete});


                flowLayoutPanel1.Controls.Add(panelSupplier);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла непредвиденная ошибка: {ex.Message}");
            }



        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Delete?", "Yes", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                var btn = (Button)sender;
                var currentId = (int)btn.Tag;

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmdDeleteData = new SqlCommand("DELETE FROM Suppliers WHERE SupplierId = @Id", conn);
                    cmdDeleteData.Parameters.AddWithValue("@Id", currentId);
                    cmdDeleteData.ExecuteNonQuery();
                }
                LoadDataSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возможно данные этой записи используются в другой таблице.Ошибка: {ex.Message}");

            }
           

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            currentId = (int)btn.Tag;

            using(var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdLoadData = new SqlCommand("SELECT * FROM Suppliers WHERE SupplierId = @Id", conn);
                cmdLoadData.Parameters.AddWithValue("@Id", currentId);

                var readerOnlyData = cmdLoadData.ExecuteReader();

                while (readerOnlyData.Read())
                {
                    txtName.Text = readerOnlyData["Name"].ToString();
                    txtContactPerson.Text = readerOnlyData["ContactPerson"].ToString();
                    txtEmail.Text = readerOnlyData["Email"].ToString();
                    txtPhone.Text = readerOnlyData["Phone"].ToString();
                    txtAdress.Text = readerOnlyData["Address"].ToString();
                }
                readerOnlyData.Close();

            }
            

        }

       

        private void ToggleSupliersStatus(int suppliersId)
        {
            using(var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdSetActive = new SqlCommand("UPDATE Suppliers SET IsActive = ~IsActive WHERE SupplierId = @Id ", conn);
                cmdSetActive.Parameters.AddWithValue("@Id", suppliersId);
                cmdSetActive.ExecuteNonQuery();

            }
            LoadDataSuppliers();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                using(var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd;
                    if (currentId == -1)
                    {
                        cmd = new SqlCommand("INSERT INTO Suppliers (Name, ContactPerson, Phone, Email, Address) VALUES (@Name, @ContactPerson, @Phone, @Email, @Address)", conn);
                        

                    }
                    else
                    {
                        cmd = new SqlCommand("UPDATE Suppliers SET Name = @Name, ContactPerson = @ContactPerson, Phone = @Phone, Email = @Email, Address = @Address WHERE SupplierId = @Id", conn);
                        cmd.Parameters.AddWithValue("@Id", currentId);
                    }

                    
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAdress.Text);

                    cmd.ExecuteNonQuery();
                    LoadDataSuppliers();
                    ClearFields();
                }
               
            }
            catch (Exception ex)
            {

            }
        }
        private void ClearFields()
        {
            currentId = -1;
            txtAdress.Clear();
            txtContactPerson.Clear();
            txtEmail.Clear();
            txtName.Clear();
            txtPhone.Clear();
          
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataSuppliers();
            ClearFields();
        }
    }
}
