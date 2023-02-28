using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHOP_DECOMPILED.Migrations
{
    public partial class v57658 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Phone_number = table.Column<string>(nullable: false),
                    Client_name = table.Column<string>(nullable: false),
                    date = table.Column<string>(nullable: false),
                    account_balance = table.Column<float>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    client_id = table.Column<int>(nullable: false),
                    LPO_Number = table.Column<int>(nullable: false),
                    D_Number = table.Column<int>(nullable: false),
                    M_s = table.Column<string>(nullable: false),
                    date = table.Column<string>(nullable: false),
                    Received_by = table.Column<string>(nullable: false),
                    Delivered_by = table.Column<string>(nullable: false),
                    Total = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    client_id = table.Column<int>(nullable: false),
                    LPO_Number = table.Column<int>(nullable: false),
                    Delivery_no = table.Column<int>(nullable: false),
                    M_s = table.Column<string>(nullable: false),
                    date = table.Column<string>(nullable: false),
                    Total = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Log_in2",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Phone_number = table.Column<string>(nullable: true),
                    Shop_name = table.Column<string>(nullable: true),
                    User_id = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_in2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Particulars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    client_id = table.Column<int>(nullable: false),
                    delivery_no = table.Column<int>(nullable: false),
                    category = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    Item_name = table.Column<string>(nullable: false),
                    total = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Particulars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    client_id = table.Column<int>(nullable: false),
                    Received_from = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Total = table.Column<float>(nullable: false),
                    Balance = table.Column<float>(nullable: false),
                    Particulars = table.Column<string>(nullable: false),
                    check_number = table.Column<string>(nullable: true),
                    Payment_mode = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Log_in2");

            migrationBuilder.DropTable(
                name: "Particulars");

            migrationBuilder.DropTable(
                name: "Receipts");
        }
    }
}
