using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.EntityFrameworkCore.SqlServer.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Area",
                table => new
                {
                    AreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UniqueIdentifier = table.Column<string>(maxLength: 20, nullable: true),
                    UIN = table.Column<string>(maxLength: 20, nullable: true),
                    FIN = table.Column<DateTime>("datetime", nullable: true),
                    UUP = table.Column<string>(maxLength: 20, nullable: true),
                    FUP = table.Column<DateTime>("datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                "AspNetForms",
                table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "AspNetMenus",
                table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    ParentId = table.Column<string>(maxLength: 450, nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Icon = table.Column<string>(maxLength: 250, nullable: true),
                    Url = table.Column<string>(maxLength: 250, nullable: true),
                    Orden = table.Column<double>(nullable: false),
                    TipoMenu = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "AspNetUsers",
                table => new
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
                    DisplayName = table.Column<string>(maxLength: 256, nullable: true),
                    LastLogon = table.Column<DateTime>(nullable: true),
                    ChangePassword = table.Column<bool>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "Country",
                table => new
                {
                    CountryId = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                "Manufacturer",
                table => new
                {
                    ManufacturerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UniqueIdentifier = table.Column<string>(maxLength: 20, nullable: true),
                    UIN = table.Column<string>(maxLength: 20, nullable: true),
                    FIN = table.Column<DateTime>("datetime", nullable: true),
                    UUP = table.Column<string>(maxLength: 20, nullable: true),
                    FUP = table.Column<DateTime>("datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                "TransactionType",
                table => new
                {
                    TransactionTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Hide = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.TransactionTypeId);
                });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AspNetRoleForms",
                table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    RoleId = table.Column<string>(maxLength: 450, nullable: false),
                    FormId = table.Column<string>(maxLength: 450, nullable: false),
                    Action = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleForms", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleForms_AspNetForms_FormId",
                        x => x.FormId,
                        "AspNetForms",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AspNetRoleForms_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AspNetRoleMenus",
                table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    RoleId = table.Column<string>(maxLength: 450, nullable: false),
                    MenuId = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleMenus", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleMenus_AspNetMenus_MenuId",
                        x => x.MenuId,
                        "AspNetMenus",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AspNetRoleMenus_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AspNetUserForms",
                table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    UserId = table.Column<string>(maxLength: 450, nullable: false),
                    FormId = table.Column<string>(maxLength: 450, nullable: false),
                    Action = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserForms", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserForms_AspNetForms_FormId",
                        x => x.FormId,
                        "AspNetForms",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AspNetUserForms_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
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
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AspNetUserMenus",
                table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    UserId = table.Column<string>(maxLength: 450, nullable: false),
                    MenuId = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserMenus", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserMenus_AspNetMenus_MenuId",
                        x => x.MenuId,
                        "AspNetMenus",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AspNetUserMenus_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
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
                        "FK_AspNetUserTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "State",
                table => new
                {
                    StateId = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        "FK_State_Country_CountryId",
                        x => x.CountryId,
                        "Country",
                        "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Item",
                table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    SKU = table.Column<string>(maxLength: 20, nullable: false),
                    Summary = table.Column<string>(maxLength: 500, nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    ManufacturerId = table.Column<int>(nullable: true),
                    MinimumStockCount = table.Column<decimal>("decimal(18, 2)", nullable: false),
                    UniqueIdentifier = table.Column<string>(maxLength: 20, nullable: true),
                    UIN = table.Column<string>(maxLength: 20, nullable: true),
                    FIN = table.Column<DateTime>("datetime", nullable: true),
                    UUP = table.Column<string>(maxLength: 20, nullable: true),
                    FUP = table.Column<DateTime>("datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        "FK_Item_Area_AreaId",
                        x => x.AreaId,
                        "Area",
                        "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Item_Manufacturer_ManufacturerId",
                        x => x.ManufacturerId,
                        "Manufacturer",
                        "ManufacturerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Location",
                table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    CountryId = table.Column<short>(nullable: true),
                    StateId = table.Column<short>(nullable: true),
                    UniqueIdentifier = table.Column<string>(maxLength: 20, nullable: true),
                    UIN = table.Column<string>(maxLength: 20, nullable: true),
                    FIN = table.Column<DateTime>("datetime", nullable: true),
                    UUP = table.Column<string>(maxLength: 20, nullable: true),
                    FUP = table.Column<DateTime>("datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        "FK_Location_Country_CountryId",
                        x => x.CountryId,
                        "Country",
                        "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Location_State_StateId",
                        x => x.StateId,
                        "State",
                        "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "ItemLocation",
                table => new
                {
                    ItemLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>("decimal(18, 2)", nullable: false),
                    UnitCost = table.Column<decimal>("decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLocation", x => x.ItemLocationId);
                    table.ForeignKey(
                        "FK_ItemLocation_Item_ItemId",
                        x => x.ItemId,
                        "Item",
                        "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_ItemLocation_Location_LocationId",
                        x => x.LocationId,
                        "Location",
                        "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Transaction",
                table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>("decimal(18, 2)", nullable: false),
                    UnitCost = table.Column<decimal>("decimal(18, 2)", nullable: false),
                    UnitSale = table.Column<decimal>("decimal(18, 2)", nullable: false),
                    AverageCost = table.Column<decimal>("decimal(18, 2)", nullable: false),
                    Comments = table.Column<string>(maxLength: 250, nullable: true),
                    TransactionDate = table.Column<DateTime>("datetime", nullable: false),
                    UniqueIdentifier = table.Column<string>(maxLength: 20, nullable: true),
                    UIN = table.Column<string>(maxLength: 20, nullable: true),
                    FIN = table.Column<DateTime>("datetime", nullable: true),
                    UUP = table.Column<string>(maxLength: 20, nullable: true),
                    FUP = table.Column<DateTime>("datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        "FK_Transaction_Item_ItemId",
                        x => x.ItemId,
                        "Item",
                        "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Transaction_Location_LocationId",
                        x => x.LocationId,
                        "Location",
                        "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Transaction_TransactionType_TransactionTypeId",
                        x => x.TransactionTypeId,
                        "TransactionType",
                        "TransactionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                "AspNetMenus",
                new[] { "Id", "Icon", "Name", "Orden", "ParentId", "TipoMenu", "Url" },
                new object[,]
                {
                    { "dd20b5b6-472f-49c4-8267-74b0440f28af", "fa fa-print", "Reportes", 5.0, null, (short)1, "/reports" },
                    { "0cc1ea20-6f37-4e62-ae66-c4937f1d02db", "fa fa-industry", "Fabricantes", 3.0, null, (short)1, "/manufacturers" },
                    { "cfd4b10d-3bdd-4eca-a10f-44829a21eca2", "fa fa-map-marker", "Almacenes", 1.0, null, (short)1, "/locations" },
                    { "2e4a8010-7a3a-444e-b8c1-6a9a934e32e6", "icon-star", "Areas", 2.0, null, (short)1, "/areas" },
                    { "d7929eda-8e48-4383-8d9d-722c06969169", "fa fa-plus", "Artículos", 4.0, null, (short)1, "/items" }
                });

            migrationBuilder.InsertData(
                "AspNetRoles",
                new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                new object[,]
                {
                    { "4fc0e346-7829-4ee6-b1eb-7a5b84f4996a", "4c6a4a31-c688-4189-9fb5-4181cb1b2464", "Standard role", "default", "DEFAULT" },
                    { "fd162655-2107-48a9-a302-6d5cf7d6d399", "7b826b78-ec2c-4b93-9bba-7a0740d9baf1", "Server administrator role", "sa", "SA" }
                });

            migrationBuilder.InsertData(
                "Country",
                new[] { "CountryId", "Name" },
                new object[,]
                {
                    { (short)139, "Otros países de América" },
                    { (short)138, "Venezuela" },
                    { (short)137, "Uruguay" },
                    { (short)136, "Surinam" },
                    { (short)133, "Guyana" },
                    { (short)134, "Paraguay" },
                    { (short)140, "Afganistán" },
                    { (short)132, "Ecuador" },
                    { (short)135, "Perú" },
                    { (short)141, "Arabia Saudí" },
                    { (short)144, "Myanmar" },
                    { (short)143, "Bangladesh" },
                    { (short)131, "Chile" },
                    { (short)145, "China" },
                    { (short)146, "Emiratos Árabes Unidos" },
                    { (short)147, "Filipinas" },
                    { (short)148, "India" },
                    { (short)149, "Indonesia" },
                    { (short)150, "Iraq" },
                    { (short)151, "Irán" },
                    { (short)142, "Bahréin" },
                    { (short)130, "Colombia" },
                    { (short)127, "Argentina" },
                    { (short)128, "Bolivia" },
                    { (short)107, "Antigua y Barbuda" },
                    { (short)109, "Barbados" },
                    { (short)110, "Belice" },
                    { (short)111, "Costa Rica" },
                    { (short)112, "Cuba" },
                    { (short)113, "Dominica" },
                    { (short)114, "El Salvador" },
                    { (short)115, "Granada" },
                    { (short)116, "Guatemala" },
                    { (short)129, "Brasil" },
                    { (short)117, "Haití" },
                    { (short)119, "Jamaica" },
                    { (short)120, "Nicaragua" },
                    { (short)121, "Panamá" },
                    { (short)122, "San Vicente y las Granadinas" },
                    { (short)123, "República Dominicana" },
                    { (short)124, "Trinidad y Tobago" },
                    { (short)125, "Santa Lucía" },
                    { (short)126, "San Cristóbal y Nieves" },
                    { (short)152, "Israel" },
                    { (short)118, "Honduras" },
                    { (short)153, "Japón" },
                    { (short)156, "Kuwait" },
                    { (short)155, "Camboya" },
                    { (short)181, "Turkmenistán" },
                    { (short)182, "Uzbekistán" },
                    { (short)183, "Bhután" },
                    { (short)184, "Palestina. Estado Observador, no miembro de Naciones Unidas" },
                    { (short)185, "Otros países de Asia" },
                    { (short)186, "Australia" },
                    { (short)187, "Fiji" },
                    { (short)188, "Nueva Zelanda" },
                    { (short)189, "Papúa Nueva Guinea" },
                    { (short)190, "Islas Salomón" },
                    { (short)191, "Samoa" },
                    { (short)192, "Tonga" },
                    { (short)193, "Vanuatu" },
                    { (short)194, "Micronesia" },
                    { (short)195, "Tuvalu" },
                    { (short)196, "Islas Cook" },
                    { (short)197, "Kiribati" },
                    { (short)198, "Nauru" },
                    { (short)199, "Palaos" },
                    { (short)200, "Timor Oriental" },
                    { (short)201, "Otros países de Oceanía" },
                    { (short)180, "Tayikistán" },
                    { (short)154, "Jordania" },
                    { (short)179, "Kirguistán" },
                    { (short)177, "Azerbaiyán" },
                    { (short)106, "México" },
                    { (short)157, "Laos" },
                    { (short)158, "Líbano" },
                    { (short)159, "Malasia" },
                    { (short)160, "Maldivas" },
                    { (short)161, "Mongolia" },
                    { (short)162, "Nepal" },
                    { (short)163, "Omán" },
                    { (short)164, "Pakistán" },
                    { (short)165, "Qatar" },
                    { (short)166, "Corea" },
                    { (short)167, "Corea del Norte" },
                    { (short)168, "Singapur" },
                    { (short)169, "Siria" },
                    { (short)170, "Sri Lanka" },
                    { (short)171, "Tailandia" },
                    { (short)172, "Turquía" },
                    { (short)173, "Vietnam" },
                    { (short)174, "Brunei" },
                    { (short)175, "Islas Marshall" },
                    { (short)176, "Yemen" },
                    { (short)178, "Kazajstán" },
                    { (short)105, "Estados Unidos de América" },
                    { (short)108, "Bahamas" },
                    { (short)103, "Otros países de África" },
                    { (short)28, "Eslovenia" },
                    { (short)29, "Albania" },
                    { (short)30, "Islandia" },
                    { (short)31, "Liechtenstein" },
                    { (short)32, "Mónaco" },
                    { (short)33, "Noruega" },
                    { (short)34, "Andorra" },
                    { (short)35, "San Marino" },
                    { (short)36, "Santa Sede" },
                    { (short)37, "Suiza" },
                    { (short)27, "Croacia" },
                    { (short)38, "Ucrania" },
                    { (short)40, "Belarús" },
                    { (short)41, "Georgia" },
                    { (short)42, "Bosnia y Herzegovina" },
                    { (short)43, "Armenia" },
                    { (short)44, "Rusia" },
                    { (short)45, "Macedonia" },
                    { (short)46, "Serbia" },
                    { (short)47, "Montenegro" },
                    { (short)104, "Canadá" },
                    { (short)49, "Burkina Faso" },
                    { (short)39, "Moldavia" },
                    { (short)50, "Angola" },
                    { (short)26, "República Eslovaca" },
                    { (short)24, "Lituania" },
                    { (short)2, "Bélgica" },
                    { (short)3, "Bulgaria" },
                    { (short)4, "Chipre" },
                    { (short)5, "Dinamarca" },
                    { (short)6, "España" },
                    { (short)7, "Finlandia" },
                    { (short)8, "Francia" },
                    { (short)9, "Grecia" },
                    { (short)10, "Hungría" },
                    { (short)11, "Irlanda" },
                    { (short)25, "República Checa" },
                    { (short)12, "Italia" },
                    { (short)14, "Malta" },
                    { (short)15, "Países Bajos" },
                    { (short)16, "Polonia" },
                    { (short)17, "Portugal" },
                    { (short)18, "Reino Unido" },
                    { (short)19, "Alemania" },
                    { (short)20, "Rumanía" },
                    { (short)21, "Suecia" },
                    { (short)22, "Letonia" },
                    { (short)23, "Estonia" },
                    { (short)13, "Luxemburgo" },
                    { (short)51, "Argelia" },
                    { (short)48, "Otros países de Europa" },
                    { (short)53, "Botswana" },
                    { (short)81, "Níger" },
                    { (short)52, "Benin" },
                    { (short)83, "República Centroafricana" },
                    { (short)84, "Sudáfrica" },
                    { (short)85, "Ruanda" },
                    { (short)86, "Santo Tomé y Príncipe" },
                    { (short)87, "Senegal" },
                    { (short)88, "Seychelles" },
                    { (short)89, "Sierra Leona" },
                    { (short)90, "Somalia" },
                    { (short)80, "Namibia" },
                    { (short)91, "Sudán" },
                    { (short)93, "Tanzania" },
                    { (short)94, "Chad" },
                    { (short)95, "Togo" },
                    { (short)96, "Túnez" },
                    { (short)97, "Uganda" },
                    { (short)98, "República Democrática del Congo" },
                    { (short)99, "Zambia" },
                    { (short)100, "Zimbabwe" },
                    { (short)101, "Eritrea" },
                    { (short)102, "Sudán del Sur" },
                    { (short)92, "Swazilandia" },
                    { (short)79, "Mozambique" },
                    { (short)82, "Nigeria" },
                    { (short)77, "Mauricio" },
                    { (short)54, "Burundi" },
                    { (short)55, "Cabo Verde" },
                    { (short)56, "Camerún" },
                    { (short)57, "Comores" },
                    { (short)58, "Congo" },
                    { (short)59, "Costa de Marfil" },
                    { (short)60, "Djibouti" },
                    { (short)78, "Mauritania" },
                    { (short)62, "Etiopía" },
                    { (short)63, "Gabón" },
                    { (short)64, "Gambia" },
                    { (short)61, "Egipto" },
                    { (short)66, "Guinea" },
                    { (short)76, "Marruecos" },
                    { (short)75, "Mali" },
                    { (short)74, "Malawi" },
                    { (short)73, "Madagascar" },
                    { (short)72, "Libia" },
                    { (short)65, "Ghana" },
                    { (short)1, "Austria" },
                    { (short)71, "Liberia" },
                    { (short)70, "Lesotho" },
                    { (short)69, "Kenia" },
                    { (short)68, "Guinea Ecuatorial" },
                    { (short)67, "Guinea-Bissau" }
                });

            migrationBuilder.InsertData(
                "TransactionType",
                new[] { "TransactionTypeId", "Hide", "Name" },
                new object[,]
                {
                    { 2, false, "Retorno - utilizable" },
                    { 1, false, "Nuevo stock" },
                    { 4, true, "Transferencia saliente" },
                    { 6, true, "Venta al cliente" },
                    { 7, true, "Stock dañado" },
                    { 3, false, "Devolución - inutilizable" },
                    { 5, true, "Transferencia entrante" }
                });

            migrationBuilder.InsertData(
                "State",
                new[] { "StateId", "CountryId", "Name" },
                new object[,]
                {
                    { (short)1, (short)123, "Azua" },
                    { (short)30, (short)123, "Santiago rodriguez" },
                    { (short)29, (short)123, "Santiago" },
                    { (short)28, (short)123, "Sanchez ramirez" },
                    { (short)27, (short)123, "San pedro de macoris" },
                    { (short)26, (short)123, "San juan" },
                    { (short)25, (short)123, "San jose de ocoa" },
                    { (short)24, (short)123, "San cristobal" },
                    { (short)23, (short)123, "Samana" },
                    { (short)22, (short)123, "Puerto plata" },
                    { (short)21, (short)123, "Peravia" },
                    { (short)20, (short)123, "Pedernales" },
                    { (short)19, (short)123, "Monte plata" },
                    { (short)18, (short)123, "Monte cristi" },
                    { (short)17, (short)123, "Monseñor nouel" },
                    { (short)16, (short)123, "Maria trinidad sanchez" },
                    { (short)15, (short)123, "La vega" },
                    { (short)14, (short)123, "La romana" },
                    { (short)13, (short)123, "La altagracia" },
                    { (short)12, (short)123, "Independencia" },
                    { (short)11, (short)123, "Hermanas mirabal" },
                    { (short)10, (short)123, "Hato mayor" },
                    { (short)9, (short)123, "Espaillat" },
                    { (short)8, (short)123, "Elias piña" },
                    { (short)7, (short)123, "El seibo" },
                    { (short)6, (short)123, "Duarte" },
                    { (short)5, (short)123, "Distrito nacional" },
                    { (short)4, (short)123, "Dajabon" },
                    { (short)3, (short)123, "Barahona" },
                    { (short)2, (short)123, "Baoruco" },
                    { (short)31, (short)123, "Santo domingo" },
                    { (short)32, (short)123, "Valverde" }
                });

            migrationBuilder.CreateIndex(
                "IX_Area_Name_UniqueIdentifier",
                "Area",
                new[] { "Name", "UniqueIdentifier" },
                unique: true,
                filter: "[UniqueIdentifier] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AspNetForms_Name",
                "AspNetForms",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetMenus_Id_ParentId",
                "AspNetMenus",
                new[] { "Id", "ParentId" },
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleForms_FormId",
                "AspNetRoleForms",
                "FormId");

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleForms_RoleId_FormId",
                "AspNetRoleForms",
                new[] { "RoleId", "FormId" },
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleMenus_MenuId",
                "AspNetRoleMenus",
                "MenuId");

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleMenus_RoleId_MenuId",
                "AspNetRoleMenus",
                new[] { "RoleId", "MenuId" },
                unique: true);

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserForms_FormId",
                "AspNetUserForms",
                "FormId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserForms_UserId_FormId",
                "AspNetUserForms",
                new[] { "UserId", "FormId" },
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserMenus_MenuId",
                "AspNetUserMenus",
                "MenuId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserMenus_UserId_MenuId",
                "AspNetUserMenus",
                new[] { "UserId", "MenuId" },
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_Country_Name",
                "Country",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Item_AreaId",
                "Item",
                "AreaId");

            migrationBuilder.CreateIndex(
                "IX_Item_ManufacturerId",
                "Item",
                "ManufacturerId");

            migrationBuilder.CreateIndex(
                "IX_Item_Name_UniqueIdentifier",
                "Item",
                new[] { "Name", "UniqueIdentifier" },
                unique: true,
                filter: "[UniqueIdentifier] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_Item_SKU_UniqueIdentifier",
                "Item",
                new[] { "SKU", "UniqueIdentifier" },
                unique: true,
                filter: "[UniqueIdentifier] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_ItemLocation_LocationId",
                "ItemLocation",
                "LocationId");

            migrationBuilder.CreateIndex(
                "IX_ItemLocation_ItemId_LocationId",
                "ItemLocation",
                new[] { "ItemId", "LocationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Location_CountryId",
                "Location",
                "CountryId");

            migrationBuilder.CreateIndex(
                "IX_Location_StateId",
                "Location",
                "StateId");

            migrationBuilder.CreateIndex(
                "IX_Location_Name_UniqueIdentifier",
                "Location",
                new[] { "Name", "UniqueIdentifier" },
                unique: true,
                filter: "[UniqueIdentifier] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_Manufacturer_Name_UniqueIdentifier",
                "Manufacturer",
                new[] { "Name", "UniqueIdentifier" },
                unique: true,
                filter: "[UniqueIdentifier] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_State_CountryId",
                "State",
                "CountryId");

            migrationBuilder.CreateIndex(
                "IX_State_Name",
                "State",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Transaction_ItemId",
                "Transaction",
                "ItemId");

            migrationBuilder.CreateIndex(
                "IX_Transaction_LocationId",
                "Transaction",
                "LocationId");

            migrationBuilder.CreateIndex(
                "IX_Transaction_TransactionTypeId",
                "Transaction",
                "TransactionTypeId");

            migrationBuilder.CreateIndex(
                "IX_TransactionType_Name",
                "TransactionType",
                "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetRoleForms");

            migrationBuilder.DropTable(
                "AspNetRoleMenus");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserForms");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserMenus");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "ItemLocation");

            migrationBuilder.DropTable(
                "Transaction");

            migrationBuilder.DropTable(
                "AspNetForms");

            migrationBuilder.DropTable(
                "AspNetMenus");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropTable(
                "AspNetUsers");

            migrationBuilder.DropTable(
                "Item");

            migrationBuilder.DropTable(
                "Location");

            migrationBuilder.DropTable(
                "TransactionType");

            migrationBuilder.DropTable(
                "Area");

            migrationBuilder.DropTable(
                "Manufacturer");

            migrationBuilder.DropTable(
                "State");

            migrationBuilder.DropTable(
                "Country");
        }
    }
}
