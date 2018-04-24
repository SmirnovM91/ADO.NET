using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shop = new DataSet();

            DataTable products = new DataTable("Products");
            {
                DataColumn id = new DataColumn("Id", typeof(int));
                DataColumn name = new DataColumn("Name", typeof(string));
                DataColumn price = new DataColumn("Price", typeof(int));
                products.Columns.AddRange(new DataColumn[] { id, name, price });
                products.PrimaryKey = new DataColumn[] { id };

                DataRow row = products.NewRow();
                row[id] = 1;
                row[name] = "IceCream";
                row[price] = 10;
                products.Rows.Add(row);
            }

            shop.Tables.Add(products);

            DataTable clients = new DataTable("Clients");
            {
                DataColumn id = new DataColumn("Id", typeof(int));
                DataColumn fname = new DataColumn("FirstName", typeof(string));
                DataColumn lname = new DataColumn("LastName", typeof(string));
                clients.Columns.AddRange(new DataColumn[] { id, fname, lname });
                clients.PrimaryKey = new DataColumn[] { id };

                DataRow row = clients.NewRow();
                row[id] = 1;
                row[fname] = "Mikhail";
                row[lname] = "Smirnov";
                clients.Rows.Add(row);
            }

            shop.Tables.Add(clients);

            DataTable employees = new DataTable("Employees");
            {
                DataColumn id = new DataColumn("Id", typeof(int));
                DataColumn fname = new DataColumn("FirstName", typeof(string));
                DataColumn lname = new DataColumn("LastName", typeof(string));
                employees.Columns.AddRange(new DataColumn[] { id, fname, lname });
                employees.PrimaryKey = new DataColumn[] { id };

                DataRow row = employees.NewRow();
                row[id] = 1;
                row[fname] = "Alex";
                row[lname] = "Smirnov";
                employees.Rows.Add(row);
            }

            shop.Tables.Add(employees);

            DataTable orders = new DataTable("Orders");
            {
                DataColumn id = new DataColumn("Id", typeof(int));
                DataColumn clientId = new DataColumn("ClientId", typeof(int));
                DataColumn employeeId = new DataColumn("EmployeeId", typeof(int));
                DataColumn orderDate = new DataColumn("OrderDate", typeof(DateTime));
                DataColumn total = new DataColumn("Total", typeof(int));
                orders.Columns.AddRange(new DataColumn[] { id, clientId, employeeId, orderDate, total });
                orders.PrimaryKey = new DataColumn[] { id };

                DataRow row = orders.NewRow();
                row[id] = 1;
                row[clientId] = 1;
                row[employeeId] = 1;
                row[orderDate] = DateTime.Today;
                row[total] = 20;
                orders.Rows.Add(row);

            }

            shop.Tables.Add(orders);

            ForeignKeyConstraint fkClient = new ForeignKeyConstraint(shop.Tables["Clients"].Columns["Id"], shop.Tables["Orders"].Columns["ClientId"]);
            ForeignKeyConstraint fkEmployee = new ForeignKeyConstraint(shop.Tables["Employees"].Columns["Id"], shop.Tables["Orders"].Columns["EmployeeId"]);

            shop.Tables["Orders"].Constraints.AddRange(new Constraint[] { fkClient, fkEmployee });

            DataTable orderDetails = new DataTable("OrderDetails");
            {
                DataColumn orderId = new DataColumn("OrderId", typeof(int));
                DataColumn productId = new DataColumn("ProductId", typeof(int));
                orderDetails.Columns.AddRange(new DataColumn[] { orderId, productId, });

                DataRow newRow = orderDetails.NewRow();
                newRow[orderId] = 1;
                newRow[productId] = 1;
                orderDetails.Rows.Add(newRow);
            }

            shop.Tables.Add(orderDetails);

            ForeignKeyConstraint fkOrder = new ForeignKeyConstraint(shop.Tables["Orders"].Columns["Id"], shop.Tables["OrderDetails"].Columns["OrderId"]);
            ForeignKeyConstraint fkProduct = new ForeignKeyConstraint(shop.Tables["Products"].Columns["Id"], shop.Tables["OrderDetails"].Columns["ProductId"]);

            shop.Tables["OrderDetails"].Constraints.AddRange(new Constraint[] { fkOrder, fkProduct });

        }
    }
}
