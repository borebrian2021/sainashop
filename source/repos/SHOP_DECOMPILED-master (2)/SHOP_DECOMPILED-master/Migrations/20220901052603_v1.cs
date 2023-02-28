using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHOP_DECOMPILED.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creditors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Customer_name = table.Column<string>(nullable: false),
                    Phone_number = table.Column<int>(nullable: false),
                    Credit = table.Column<double>(nullable: false),
                    Date_created = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Creditors_fuel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Customer_name = table.Column<string>(nullable: false),
                    Phone_number = table.Column<int>(nullable: false),
                    station_id = table.Column<int>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    Date_created = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditors_fuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Client_id = table.Column<int>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    Date_created = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Credits_fuel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Client_id = table.Column<int>(nullable: false),
                    Fuel = table.Column<string>(nullable: true),
                    Ammount_in_litres = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    Number_plate = table.Column<string>(nullable: true),
                    station_id = table.Column<int>(nullable: false),
                    Date_created = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits_fuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Expense = table.Column<string>(nullable: false),
                    Ammount = table.Column<double>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Agent_id = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Expiries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Item_name = table.Column<string>(nullable: true),
                    Date_created = table.Column<string>(nullable: true),
                    Expiry_date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expiries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fuel_category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fuel_id = table.Column<int>(nullable: false),
                    Station_id = table.Column<int>(nullable: false),
                    Fuel_names = table.Column<string>(nullable: false),
                    Tank_capacity = table.Column<double>(nullable: false),
                    Current_quantity = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fuel_station_reg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Owners_id = table.Column<string>(nullable: false),
                    Station_Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel_station_reg", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "General_sales_history",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Attendant_id = table.Column<int>(nullable: false),
                    Total_cash_made = table.Column<double>(nullable: false),
                    Cash_paybill = table.Column<double>(nullable: false),
                    Cash_at_hand = table.Column<double>(nullable: false),
                    Expenses = table.Column<double>(nullable: false),
                    On_credit = table.Column<double>(nullable: false),
                    Availlable_cash = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General_sales_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Individual_fuel_Sales_history",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(nullable: false),
                    Fuel_id = table.Column<int>(nullable: false),
                    Station_id = table.Column<int>(nullable: false),
                    Dispenser_id = table.Column<int>(nullable: false),
                    Previous_meter = table.Column<double>(nullable: false),
                    Closing_meter = table.Column<double>(nullable: false),
                    Litres_sold = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Remaining_fuel = table.Column<double>(nullable: false),
                    Cash_made = table.Column<double>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individual_fuel_Sales_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Log_in",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Full_name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Shop_name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    strRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_in", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Meter_readings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fuel_id = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: false),
                    Station_id = table.Column<int>(nullable: false),
                    Current_readings = table.Column<double>(nullable: false),
                    Previous_readings = table.Column<double>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Agent_id = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meter_readings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_history",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Client_id = table.Column<int>(nullable: false),
                    Ammount_paid = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    Date_created = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_history_fuel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Client_id = table.Column<int>(nullable: false),
                    Ammount_paid = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    Date_created = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_history_fuel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Refill_history",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fuel_id = table.Column<int>(nullable: false),
                    Ammount_refilled = table.Column<double>(nullable: false),
                    Date_refilled = table.Column<string>(nullable: false),
                    initial_readings = table.Column<double>(nullable: false),
                    final_readings = table.Column<double>(nullable: false),
                    agent_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refill_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Restock_history",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Item_id = table.Column<int>(nullable: false),
                    Date_restock = table.Column<string>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    new_quanity = table.Column<double>(nullable: false),
                    Prev_quantity = table.Column<double>(nullable: false),
                    quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restock_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shop_items",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Item_name = table.Column<string>(nullable: false),
                    Item_price = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    DateTime = table.Column<string>(nullable: false),
                    Cost_price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SMS_Config",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SSD = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMS_Config", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SMS_Settings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fuel_id = table.Column<string>(nullable: true),
                    Level = table.Column<double>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    Last_set = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMS_Settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sold_items",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Item_id = table.Column<int>(nullable: false),
                    quantity_sold = table.Column<double>(nullable: false),
                    Total_cash_made = table.Column<double>(nullable: false),
                    Cost_cash = table.Column<double>(nullable: false),
                    Total_Cost_cash = table.Column<double>(nullable: false),
                    Profit = table.Column<double>(nullable: false),
                    DateTime = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sold_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Supliers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Company_name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "System_users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Full_name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    National_id = table.Column<int>(nullable: false),
                    station_id = table.Column<int>(nullable: false),
                    Roles = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creditors");

            migrationBuilder.DropTable(
                name: "Creditors_fuel");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Credits_fuel");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Expiries");

            migrationBuilder.DropTable(
                name: "Fuel_category");

            migrationBuilder.DropTable(
                name: "Fuel_station_reg");

            migrationBuilder.DropTable(
                name: "General_sales_history");

            migrationBuilder.DropTable(
                name: "Individual_fuel_Sales_history");

            migrationBuilder.DropTable(
                name: "Log_in");

            migrationBuilder.DropTable(
                name: "Meter_readings");

            migrationBuilder.DropTable(
                name: "Payment_history");

            migrationBuilder.DropTable(
                name: "Payment_history_fuel");

            migrationBuilder.DropTable(
                name: "Refill_history");

            migrationBuilder.DropTable(
                name: "Restock_history");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Shop_items");

            migrationBuilder.DropTable(
                name: "SMS_Config");

            migrationBuilder.DropTable(
                name: "SMS_Settings");

            migrationBuilder.DropTable(
                name: "sold_items");

            migrationBuilder.DropTable(
                name: "Supliers");

            migrationBuilder.DropTable(
                name: "System_users");
        }
    }
}
