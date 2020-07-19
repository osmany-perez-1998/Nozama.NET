using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISProject.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true),
                    ProductSaleID = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SellerId = table.Column<string>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Seen = table.Column<bool>(nullable: false),
                    CurrentPrice = table.Column<double>(nullable: false),
                    PriceStep = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionHeader_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    OrderTime = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeader_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    SellerId = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSale_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSale_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    AuctionId = table.Column<int>(nullable: false),
                    LastPriceOffered = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionUser_AuctionHeader_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SendToUser = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    NotiDate = table.Column<DateTime>(nullable: false),
                    Seen = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    AuctionHeaderID = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    OrderHeaderID = table.Column<int>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_AuctionHeader_AuctionHeaderID",
                        column: x => x.AuctionHeaderID,
                        principalTable: "AuctionHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_OrderHeader_OrderHeaderID",
                        column: x => x.OrderHeaderID,
                        principalTable: "OrderHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuctionProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(nullable: false),
                    AuctionId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    NotiAuctionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionProduct_AuctionHeader_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionProduct_Notification_NotiAuctionId",
                        column: x => x.NotiAuctionId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuctionProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AmountLeft = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    NotiBuyId = table.Column<int>(nullable: true),
                    NotiSellId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Notification_NotiBuyId",
                        column: x => x.NotiBuyId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Notification_NotiSellId",
                        column: x => x.NotiSellId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeader_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProductSale_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductSale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Seller", "d473c797-4a5e-4278-bf68-9c6debb11628", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Manager", "9c829e8a-5fbd-40d2-80bb-d74938e0722b", "Manager", "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0Customer", "f32d358c-8315-4de2-aca2-9858e54f9a6f", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "101", 0, "2c6929a6-a7e5-4123-a967-83619bf41340", "User", "Customer10@fake.com", true, true, null, "CUSTOMER10@FAKE.COM", "CUSTOMER10@FAKE.COM", "AQAAAAEAACcQAAAAEJIofSBvpn7q4vK6fr6qqBX40h9BtcpEW4kAcOq47GS/nWkcSJpk5zLxn/OYaHSRgw==", null, false, "935bd5e7-5ae3-4eec-8867-f536188a1f51", false, "Customer10@fake.com", "Customer10" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "91", 0, "e26b6766-f0ac-4435-89d2-69e7b941caa0", "User", "Customer9@fake.com", true, true, null, "CUSTOMER9@FAKE.COM", "CUSTOMER9@FAKE.COM", "AQAAAAEAACcQAAAAENEgoIzZV+y20XKlsZOgEviZ1Pi6mub+UWoeGhWb701gRTEKl4Utxhm2lr5i+BC+BQ==", null, false, "269ac44c-fa06-4736-a407-06d2c5c64676", false, "Customer9@fake.com", "Customer9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "81", 0, "5935b56d-8595-485a-ac1c-74dc85bc458c", "User", "Customer8@fake.com", true, true, null, "CUSTOMER8@FAKE.COM", "CUSTOMER8@FAKE.COM", "AQAAAAEAACcQAAAAEDBGGuTwn5XkN/oBenyd5cVI8ZMh9+6csI3DbIsnsITWbMuWFEKokMTmCcGkxJMbhQ==", null, false, "c5374063-c269-45a6-b346-998460c81054", false, "Customer8@fake.com", "Customer8" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "71", 0, "10474a2e-c1b6-4308-b786-a040e1c648f5", "User", "Customer7@fake.com", true, true, null, "CUSTOMER7@FAKE.COM", "CUSTOMER7@FAKE.COM", "AQAAAAEAACcQAAAAEN2FECoKuzVgAICxFgCGHRC8h5IUk3O1nZD/rTpbkj7IqRFHvUrzfRAh9FTkkb4CLg==", null, false, "aefd8fce-0085-46fe-90d4-2c760973e839", false, "Customer7@fake.com", "Customer7" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "61", 0, "bf1cd123-6f10-4ac7-b9f9-a21023de8ad0", "User", "Customer6@fake.com", true, true, null, "CUSTOMER6@FAKE.COM", "CUSTOMER6@FAKE.COM", "AQAAAAEAACcQAAAAEB1OkcROfw6jEBDNy1Z1rUgTtDf07y0Y0gmA9WLSblAu+Tc5i1BZ2kTIqNut6earKw==", null, false, "3a85634a-cb22-4ced-aa3b-e7f2bd15fdc8", false, "Customer6@fake.com", "Customer6" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "51", 0, "b524413e-3f24-4485-9eba-905c0780ece5", "User", "Customer5@fake.com", true, true, null, "CUSTOMER5@FAKE.COM", "CUSTOMER5@FAKE.COM", "AQAAAAEAACcQAAAAEKdBgBVOr8y7rCJjM2ajFw7AHYpH3Hw/dfZKeDQV3xOePqRuwAOE8vFIy2tBaWjZ7g==", null, false, "2dd6750a-41e8-432a-9920-83ab8b07c398", false, "Customer5@fake.com", "Customer5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "82", 0, "f3756405-d1c1-4d32-b00c-016bff8fb68d", "Seller", "Seller8@fake.com", true, true, null, "SELLER8@FAKE.COM", "SELLER8@FAKE.COM", "AQAAAAEAACcQAAAAECLnfzOW8Eh2dr0NMxAU0ajKiQp3Bwh2LOxdenB33mAtDu/Gp9tDA3accp9F3jiH6w==", null, false, "fba80139-6131-4928-954e-8fb15161442d", false, "Seller8@fake.com", "Seller8", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "31", 0, "cb4d2e42-6e07-4bc5-a877-187ceea84c07", "User", "Customer3@fake.com", true, true, null, "CUSTOMER3@FAKE.COM", "CUSTOMER3@FAKE.COM", "AQAAAAEAACcQAAAAEEBsuncGrPDlAEwTaYO3d017GEfI1KP/Tk0cX0WiXpPRFeqNpyXp+8RaI0VjUDuA9Q==", null, false, "303fa543-1837-47f4-a5a7-b3480576be5b", false, "Customer3@fake.com", "Customer3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "21", 0, "6c533e81-d7a3-4d09-b479-e1e6179e249b", "User", "Customer2@fake.com", true, true, null, "CUSTOMER2@FAKE.COM", "CUSTOMER2@FAKE.COM", "AQAAAAEAACcQAAAAEADO502ZotX8smpAgMRmfrCVZuM6/5G1n/yzlvkWidEPwuda5+hfALiPcLdDc56XBA==", null, false, "453c7363-2356-4e81-abd6-46b335a13c8c", false, "Customer2@fake.com", "Customer2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "11", 0, "0f89c37e-4805-4d86-9013-989033c3c2c5", "User", "Customer1@fake.com", true, true, null, "CUSTOMER1@FAKE.COM", "CUSTOMER1@FAKE.COM", "AQAAAAEAACcQAAAAEMGfC+kVi/o66QjDJNGNHGwlztQ6aAOIObLmhsTzfCG9p1yUIL8yyDZLit8H4F10Vw==", null, false, "6a1d76ff-aaf2-4cbc-90f8-e31fd71ee4b5", false, "Customer1@fake.com", "Customer1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "21123111111", 0, "e9491515-dace-4e30-8795-be9c6fb6a165", "Seller", "admin@fake.com", true, true, null, "ADMIN@FAKE.COM", "ADMIN@FAKE.COM", "AQAAAAEAACcQAAAAEH2FdReimaM3Z3ccUEYezxDOCPs6HShekEWTbCQqiG2ECBEfay9+UixfR2hhR4ZVWg==", null, false, "bfdb3126-4bcb-4949-ae95-09be2456a6ec", false, "admin@fake.com", "admin", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "102", 0, "73ec1d8c-cbbb-4211-8769-c2f007c9d633", "Seller", "Seller10@fake.com", true, true, null, "SELLER10@FAKE.COM", "SELLER10@FAKE.COM", "AQAAAAEAACcQAAAAEKIdIM9ivTKMVUS2zo7rC7hlUdQsA57eBDTSjem1Jw7M83Duf0NSr23UyNqvJ/B7WQ==", null, false, "e458ce10-acd1-4801-ab5d-5a7868b95c35", false, "Seller10@fake.com", "Seller10", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "92", 0, "422f045e-fa11-403e-bb0c-03a5c234507b", "Seller", "Seller9@fake.com", true, true, null, "SELLER9@FAKE.COM", "SELLER9@FAKE.COM", "AQAAAAEAACcQAAAAEIsGgB6epNIpnnq3RP2a3PJtcxHGX141MviB2RpEypR5/PW9detTMIT/Rx0w9e2T4Q==", null, false, "9b440a3c-4353-4233-b201-80beadd376ad", false, "Seller9@fake.com", "Seller9", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name" },
                values: new object[] { "41", 0, "5849a75a-6fea-4cc2-b057-d122b3120a7e", "User", "Customer4@fake.com", true, true, null, "CUSTOMER4@FAKE.COM", "CUSTOMER4@FAKE.COM", "AQAAAAEAACcQAAAAEPcC+SEEvBArGM9u1uh7HQzTxWvPlsuQQPX0kWDfLaRGD/xHaIf6soMON8uW1FhoKA==", null, false, "21b70497-1fd4-4941-bf20-61bff05d0eec", false, "Customer4@fake.com", "Customer4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "72", 0, "7090cd44-e909-4867-ac03-51d33c65e30b", "Seller", "Seller7@fake.com", true, true, null, "SELLER7@FAKE.COM", "SELLER7@FAKE.COM", "AQAAAAEAACcQAAAAENaSPdtl0oQ5ECWuJCfXowPfdRvPuNlPL2Hvf2pPLQCyGDbMJWj9kFfgydjjHhWV4g==", null, false, "696d3595-f8ae-474c-bf45-3343a564df7c", false, "Seller7@fake.com", "Seller7", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "52", 0, "a4777c4d-5e58-45ea-a138-ee52f2c2b14b", "Seller", "Seller5@fake.com", true, true, null, "SELLER5@FAKE.COM", "SELLER5@FAKE.COM", "AQAAAAEAACcQAAAAENFzbrJWE9vf1/Xc/h1LTj8IAOo3SX+5wXkYefm9BJv7cwSxMWGmyF3DFrHXwO2nKg==", null, false, "b63b562f-3a9e-4f2f-b561-bd8c187d33a8", false, "Seller5@fake.com", "Seller5", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "42", 0, "0470249a-cc3d-4dbb-ba37-3f26174e334e", "Seller", "Seller4@fake.com", true, true, null, "SELLER4@FAKE.COM", "SELLER4@FAKE.COM", "AQAAAAEAACcQAAAAEORzS3f9vdn7qXg5h6q1UT0RsJjmqtmIXCBprjiRumpQxxULbx/S6mzqTFZg3n/Gag==", null, false, "b9e26c1b-66b2-4d21-a5b1-fbcc1ae58433", false, "Seller4@fake.com", "Seller4", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "32", 0, "1dbf2993-3c4e-4dd3-b6f8-55b9f3f8d7c4", "Seller", "Seller3@fake.com", true, true, null, "SELLER3@FAKE.COM", "SELLER3@FAKE.COM", "AQAAAAEAACcQAAAAEE7oFSxgFGPMnSpBLGi57SxuHuKVLf3r04ep4kBqVPOCi+t5FBW8GGke+uo/vVP1lg==", null, false, "7f32faba-e59d-43e6-bcea-dc63dcc6b4d4", false, "Seller3@fake.com", "Seller3", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "22", 0, "205cb0a7-124a-49d9-bd80-df538999176e", "Seller", "Seller2@fake.com", true, true, null, "SELLER2@FAKE.COM", "SELLER2@FAKE.COM", "AQAAAAEAACcQAAAAEHAbY+fVv1YV2QDFIAypErA7ZpJNDDrdu9lqf+mTmUkJtC5lLMi+NehuJXFcN3IuNg==", null, false, "fa48e0a7-febb-497f-82f5-7b05f4394e29", false, "Seller2@fake.com", "Seller2", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "12", 0, "d9f9376a-b588-441b-bee4-b042ee60866e", "Seller", "Seller1@fake.com", true, true, null, "SELLER1@FAKE.COM", "SELLER1@FAKE.COM", "AQAAAAEAACcQAAAAEDaQnYN1tr8rHx8KiSvY/7LOaJdRR537uaPhIq16fJuy6MmRc1vNqzzBCYu5Zlz0NA==", null, false, "856f6722-99ed-4515-98d8-b4ff6959a7cb", false, "Seller1@fake.com", "Seller1", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Name", "Rating" },
                values: new object[] { "62", 0, "4f70a730-f674-460e-9ff0-971a26679c57", "Seller", "Seller6@fake.com", true, true, null, "SELLER6@FAKE.COM", "SELLER6@FAKE.COM", "AQAAAAEAACcQAAAAEAzFdGX0uViVxW91uQIoyW4GnwpnKHzuASpNe49sRWaRUYT36BIlJrARpOyOaCwqZw==", null, false, "8bb6facf-8d58-4c58-896a-b32ad3d552ce", false, "Seller6@fake.com", "Seller6", 0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 100, "Descripcion del producto10", "Producto10" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 90, "Descripcion del producto9", "Producto9" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 80, "Descripcion del producto8", "Producto8" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 70, "Descripcion del producto7", "Producto7" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 60, "Descripcion del producto6", "Producto6" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 50, "Descripcion del producto5", "Producto5" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 40, "Descripcion del producto4", "Producto4" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 30, "Descripcion del producto3", "Producto3" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 20, "Descripcion del producto2", "Producto2" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 10, "Descripcion del producto1", "Producto1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "11", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "41", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "51", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "61", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "71", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "81", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "91", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "101", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "31", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "21123111111", "a18be9c0Manager" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "22", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "32", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "42", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "52", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "62", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "72", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "82", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "12", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "21", "a18be9c0Customer" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "102", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "92", "a18be9c0Seller" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 75, new DateTime(2022, 7, 19, 9, 15, 26, 636, DateTimeKind.Local).AddTicks(6941), 10.0, new DateTime(2022, 7, 20, 2, 15, 26, 636, DateTimeKind.Local).AddTicks(6989), 7.0, false, "72" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 35, new DateTime(2022, 7, 19, 9, 15, 26, 609, DateTimeKind.Local).AddTicks(6983), 6.0, new DateTime(2022, 7, 19, 9, 15, 26, 609, DateTimeKind.Local).AddTicks(7050), 3.0, false, "32" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 55, new DateTime(2022, 7, 19, 9, 15, 26, 623, DateTimeKind.Local).AddTicks(3351), 8.0, new DateTime(2022, 7, 19, 9, 15, 26, 623, DateTimeKind.Local).AddTicks(3402), 5.0, false, "52" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 95, new DateTime(2022, 7, 19, 9, 15, 26, 649, DateTimeKind.Local).AddTicks(9314), 12.0, new DateTime(2022, 7, 20, 4, 15, 26, 649, DateTimeKind.Local).AddTicks(9357), 9.0, false, "92" });

            migrationBuilder.InsertData(
                table: "AuctionHeader",
                columns: new[] { "Id", "BeginDate", "CurrentPrice", "EndDate", "PriceStep", "Seen", "SellerId" },
                values: new object[] { 15, new DateTime(2022, 7, 19, 14, 15, 26, 592, DateTimeKind.Local).AddTicks(1401), 1.0, new DateTime(2022, 7, 19, 20, 15, 26, 595, DateTimeKind.Local).AddTicks(6786), 1.0, false, "12" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 34, "NotiRole", "Customer3 wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "31" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 64, "NotiRole", "Customer6 wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "61" });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "Discriminator", "Message", "NotiDate", "Seen", "SendToUser", "UserID" },
                values: new object[] { 94, "NotiRole", "Customer9 wants to become a Seller", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "All_A", "91" });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 80003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11.0, 10, "82", 9 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 8003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default.png", 11.0, 80, "82", 9 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 7003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default.png", 11.0, 70, "72", 8 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 10003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default.png", 12.0, 100, "102", 11 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 6003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default.png", 10.0, 60, "62", 7 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 5003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default.png", 10.0, 50, "52", 6 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 4003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default.png", 9.0, 40, "42", 5 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 3003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default.png", 9.0, 30, "32", 4 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 2003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default.png", 8.0, 20, "22", 3 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 1003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default.png", 8.0, 10, "12", 2 });

            migrationBuilder.InsertData(
                table: "ProductSale",
                columns: new[] { "Id", "Date", "Image", "Price", "ProductId", "SellerId", "Units" },
                values: new object[] { 9003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/default.png", 12.0, 90, "92", 10 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 16, 15, null, 10, 1 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 100006, 15, null, 20, 1 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 36, 35, null, 30, 2 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 300006, 35, null, 40, 2 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 56, 55, null, 50, 3 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 500006, 55, null, 60, 3 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 76, 75, null, 70, 4 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 700006, 75, null, 80, 4 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 96, 95, null, 90, 5 });

            migrationBuilder.InsertData(
                table: "AuctionProduct",
                columns: new[] { "Id", "AuctionId", "NotiAuctionId", "ProductId", "Quantity" },
                values: new object[] { 900006, 95, null, 100, 5 });

            migrationBuilder.InsertData(
                table: "AuctionUser",
                columns: new[] { "Id", "AuctionId", "LastPriceOffered", "UserId" },
                values: new object[] { 30000007, 35, 4.0, "41" });

            migrationBuilder.InsertData(
                table: "AuctionUser",
                columns: new[] { "Id", "AuctionId", "LastPriceOffered", "UserId" },
                values: new object[] { 37, 35, 6.0, "31" });

            migrationBuilder.InsertData(
                table: "AuctionUser",
                columns: new[] { "Id", "AuctionId", "LastPriceOffered", "UserId" },
                values: new object[] { 77, 75, 10.0, "71" });

            migrationBuilder.InsertData(
                table: "AuctionUser",
                columns: new[] { "Id", "AuctionId", "LastPriceOffered", "UserId" },
                values: new object[] { 97, 95, 12.0, "91" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuctionHeader_SellerId",
                table: "AuctionHeader",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionProduct_AuctionId",
                table: "AuctionProduct",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionProduct_NotiAuctionId",
                table: "AuctionProduct",
                column: "NotiAuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionProduct_ProductId",
                table: "AuctionProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionUser_AuctionId",
                table: "AuctionUser",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionUser_UserId",
                table: "AuctionUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_AuctionHeaderID",
                table: "Notification",
                column: "AuctionHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_OrderHeaderID",
                table: "Notification",
                column: "OrderHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserID",
                table: "Notification",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_NotiBuyId",
                table: "OrderDetails",
                column: "NotiBuyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_NotiSellId",
                table: "OrderDetails",
                column: "NotiSellId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeader_UserId",
                table: "OrderHeader",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_ProductId",
                table: "ProductSale",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_SellerId",
                table: "ProductSale",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuctionProduct");

            migrationBuilder.DropTable(
                name: "AuctionUser");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProductSale");

            migrationBuilder.DropTable(
                name: "AuctionHeader");

            migrationBuilder.DropTable(
                name: "OrderHeader");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
