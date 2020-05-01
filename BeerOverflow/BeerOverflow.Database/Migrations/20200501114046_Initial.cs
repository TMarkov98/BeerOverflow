using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
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
                    IsBanned = table.Column<bool>(nullable: false),
                    BanReason = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "Breweries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breweries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    BreweryId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AlcoholByVolume = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beers_BeerTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "BeerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeersDrank",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BeerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeersDrank", x => new { x.UserId, x.BeerId });
                    table.ForeignKey(
                        name: "FK_BeersDrank_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeersDrank_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    BeerId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.BeerId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Likes_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Text = table.Column<string>(nullable: false),
                    TargetBeerId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Beers_TargetBeerId",
                        column: x => x.TargetBeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistBeers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BeerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistBeers", x => new { x.UserId, x.BeerId });
                    table.ForeignKey(
                        name: "FK_WishlistBeers_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistBeers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 3, "065415ee-a0aa-47af-8f1a-d76b07a831ab", "Guest", "GUEST" },
                    { 2, "8d21970e-da1a-48bf-8c38-f6c432ff24dc", "User", "USER" },
                    { 1, "a73b2f1e-00c6-411b-8602-2eade4f2f1d1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BanReason", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsBanned", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 5, 0, null, "18960580-0936-4896-9b78-e9892c1db320", new DateTime(2020, 5, 1, 14, 40, 42, 962, DateTimeKind.Local).AddTicks(1600), null, "Slavcho@biri.com", false, false, false, false, null, null, "SLAVCHO@BIRI.COM", "SLAVCHO", null, "08884204200", false, null, false, "Slavcho" },
                    { 3, 0, null, "7aadf6f7-a036-436f-9557-e0248972626f", new DateTime(2020, 5, 1, 14, 40, 42, 962, DateTimeKind.Local).AddTicks(1339), null, "Gosho@biri.com", false, false, false, false, null, null, "GOSHO@BIRI.COM", "GOSHO", null, "0895623545", false, null, false, "Gosho" },
                    { 2, 0, null, "04f1fe2c-03a6-4c24-9ebc-4f6b8c8ed71f", new DateTime(2020, 5, 1, 14, 40, 42, 961, DateTimeKind.Local).AddTicks(7759), null, "Pesho@biri.com", false, false, false, false, null, null, "PESHO@BIRI.COM", "PESHO", null, "0888696969", false, null, false, "Pesho" },
                    { 1, 0, null, "98797215-b865-46c4-ae9f-fb61d701d571", new DateTime(2020, 5, 1, 11, 40, 42, 755, DateTimeKind.Utc).AddTicks(7319), null, "grand_master@biri.com", false, false, false, true, null, null, "GRAND_MASTER@BIRI.COM", "GRAND_MASTER@BIRI.COM", "AQAAAAEAACcQAAAAEEs8JyQOWICFCmnxDHooKYNqlS7ytQ0Hq0IR6OF4kbOMsaAFaQ5aduV3nYNVgwd+hA==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "grand_master@biri.com" },
                    { 4, 0, null, "abb2893f-8f61-479d-9d8f-1c8570a02705", new DateTime(2020, 5, 1, 14, 40, 42, 962, DateTimeKind.Local).AddTicks(1474), null, "Tosho@biri.com", false, false, false, false, null, null, "TOSHO@BIRI.COM", "TOSHO", null, "08884201333", false, null, false, "Tosho" }
                });

            migrationBuilder.InsertData(
                table: "BeerTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 14, new DateTime(2020, 5, 1, 14, 40, 42, 951, DateTimeKind.Local).AddTicks(5596), null, false, null, "Cider" },
                    { 13, new DateTime(2020, 5, 1, 14, 40, 42, 951, DateTimeKind.Local).AddTicks(5511), null, false, null, "Bock" },
                    { 12, new DateTime(2020, 5, 1, 14, 40, 42, 951, DateTimeKind.Local).AddTicks(5426), null, false, null, "Mead" },
                    { 1, new DateTime(2020, 5, 1, 14, 40, 42, 949, DateTimeKind.Local).AddTicks(3698), null, false, null, "Pale Lager" },
                    { 10, new DateTime(2020, 5, 1, 14, 40, 42, 951, DateTimeKind.Local).AddTicks(5201), null, false, null, "Stout" },
                    { 9, new DateTime(2020, 5, 1, 14, 40, 42, 951, DateTimeKind.Local).AddTicks(4471), null, false, null, "Porter" },
                    { 2, new DateTime(2020, 5, 1, 14, 40, 42, 950, DateTimeKind.Local).AddTicks(4893), null, false, null, "Blonde Ale" },
                    { 3, new DateTime(2020, 5, 1, 14, 40, 42, 950, DateTimeKind.Local).AddTicks(5305), null, false, null, "Hefewizen" },
                    { 4, new DateTime(2020, 5, 1, 14, 40, 42, 950, DateTimeKind.Local).AddTicks(5412), null, false, null, "Pale Ale" },
                    { 5, new DateTime(2020, 5, 1, 14, 40, 42, 950, DateTimeKind.Local).AddTicks(5533), null, false, null, "IPA" },
                    { 6, new DateTime(2020, 5, 1, 14, 40, 42, 950, DateTimeKind.Local).AddTicks(5716), null, false, null, "Amber Ale" },
                    { 7, new DateTime(2020, 5, 1, 14, 40, 42, 951, DateTimeKind.Local).AddTicks(4208), null, false, null, "Irish Red Ale" },
                    { 11, new DateTime(2020, 5, 1, 14, 40, 42, 951, DateTimeKind.Local).AddTicks(5340), null, false, null, "Pilsner" },
                    { 8, new DateTime(2020, 5, 1, 14, 40, 42, 951, DateTimeKind.Local).AddTicks(4385), null, false, null, "Brown Ale" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 170, "PW", "Palau" },
                    { 169, "PK", "Pakistan" },
                    { 168, "OM", "Oman" },
                    { 167, "NO", "Norway" },
                    { 166, "MP", "Northern Mariana Islands" },
                    { 162, "NU", "Niue" },
                    { 164, "KP", "North Korea" },
                    { 163, "NF", "Norfolk Island" },
                    { 171, "PS", "Palestinian Authority" },
                    { 161, "NG", "Nigeria" },
                    { 165, "MK", "North Macedonia" },
                    { 172, "PA", "Panama" },
                    { 177, "PN", "Pitcairn Islands" },
                    { 174, "PY", "Paraguay" },
                    { 175, "PE", "Peru" },
                    { 176, "PH", "Philippines" },
                    { 160, "NE", "Niger" },
                    { 178, "PL", "Poland" },
                    { 179, "PT", "Portugal" },
                    { 180, "PR", "Puerto Rico" },
                    { 181, "QA", "Qatar" },
                    { 182, "RE", "Réunion" },
                    { 183, "RO", "Romania" },
                    { 184, "RU", "Russia" },
                    { 185, "RW", "Rwanda" },
                    { 173, "PG", "Papua New Guinea" },
                    { 159, "NI", "Nicaragua" },
                    { 154, "NR", "Nauru" },
                    { 157, "NC", "New Caledonia" },
                    { 130, "LU", "Luxembourg" },
                    { 131, "MO", "Macao SAR" },
                    { 132, "MG", "Madagascar" },
                    { 133, "MW", "Malawi" },
                    { 134, "MY", "Malaysia" },
                    { 135, "MV", "Maldives" },
                    { 136, "ML", "Mali" },
                    { 137, "MT", "Malta" },
                    { 138, "MH", "Marshall Islands" },
                    { 139, "MQ", "Martinique" },
                    { 140, "MR", "Mauritania" },
                    { 141, "MU", "Mauritius" },
                    { 142, "YT", "Mayotte" },
                    { 143, "MX", "Mexico" },
                    { 144, "FM", "Micronesia" },
                    { 145, "MD", "Moldova" },
                    { 146, "MC", "Monaco" },
                    { 147, "MN", "Mongolia" },
                    { 148, "ME", "Montenegro" },
                    { 149, "MS", "Montserrat" },
                    { 150, "MA", "Morocco" },
                    { 151, "MZ", "Mozambique" },
                    { 152, "MM", "Myanmar" },
                    { 153, "NA", "Namibia" },
                    { 186, "BL", "Saint Barthélemy" },
                    { 155, "NP", "Nepal" },
                    { 156, "NL", "Netherlands" },
                    { 158, "NZ", "New Zealand" },
                    { 187, "KN", "Saint Kitts and Nevis" },
                    { 192, "WS", "Samoa" },
                    { 189, "MF", "Saint Martin" },
                    { 222, "TG", "Togo" },
                    { 223, "TK", "Tokelau" },
                    { 224, "TO", "Tonga" },
                    { 225, "TT", "Trinidad and Tobago" },
                    { 226, "TN", "Tunisia" },
                    { 227, "TR", "Turkey" },
                    { 228, "TM", "Turkmenistan" },
                    { 229, "TC", "Turks and Caicos Islands" },
                    { 230, "TV", "Tuvalu" },
                    { 231, "UM", "U.S. Outlying Islands" },
                    { 232, "VI", "U.S. Virgin Islands" },
                    { 233, "UG", "Uganda" },
                    { 234, "UA", "Ukraine" },
                    { 235, "AE", "United Arab Emirates" },
                    { 236, "GB", "United Kingdom" },
                    { 237, "US", "United States" },
                    { 238, "UY", "Uruguay" },
                    { 239, "UZ", "Uzbekistan" },
                    { 240, "VU", "Vanuatu" },
                    { 241, "VA", "Vatican City" },
                    { 242, "VE", "Venezuela" },
                    { 243, "VN", "Vietnam" },
                    { 244, "WF", "Wallis and Futuna" },
                    { 245, "001", "World" },
                    { 246, "YE", "Yemen" },
                    { 247, "ZM", "Zambia" },
                    { 248, "ZW", "Zimbabwe" },
                    { 221, "TL", "Timor-Leste" },
                    { 188, "LC", "Saint Lucia" },
                    { 220, "TH", "Thailand" },
                    { 218, "TJ", "Tajikistan" },
                    { 190, "PM", "Saint Pierre and Miquelon" },
                    { 191, "VC", "Saint Vincent and the Grenadines" },
                    { 193, "SM", "San Marino" },
                    { 194, "ST", "São Tomé and Príncipe" },
                    { 195, "SA", "Saudi Arabia" },
                    { 196, "SN", "Senegal" },
                    { 197, "RS", "Serbia" },
                    { 198, "SC", "Seychelles" },
                    { 199, "SL", "Sierra Leone" },
                    { 200, "SG", "Singapore" },
                    { 201, "SX", "Sint Maarten" },
                    { 202, "SK", "Slovakia" },
                    { 203, "SI", "Slovenia" },
                    { 204, "SB", "Solomon Islands" },
                    { 205, "SO", "Somalia" },
                    { 206, "ZA", "South Africa" },
                    { 207, "SS", "South Sudan" },
                    { 208, "ES", "Spain" },
                    { 209, "LK", "Sri Lanka" },
                    { 210, "SH", "St Helena, Ascension, Tristan da Cunha" },
                    { 211, "SD", "Sudan" },
                    { 212, "SR", "Suriname" },
                    { 213, "SJ", "Svalbard and Jan Mayen" },
                    { 214, "SE", "Sweden" },
                    { 215, "CH", "Switzerland" },
                    { 216, "SY", "Syria" },
                    { 217, "TW", "Taiwan" },
                    { 219, "TZ", "Tanzania" },
                    { 129, "LT", "Lithuania" },
                    { 127, "LY", "Libya" },
                    { 126, "LR", "Liberia" },
                    { 33, "BN", "Brunei" },
                    { 34, "BG", "Bulgaria" },
                    { 35, "BF", "Burkina Faso" },
                    { 36, "BI", "Burundi" },
                    { 37, "CV", "Cabo Verde" },
                    { 38, "KH", "Cambodia" },
                    { 39, "CM", "Cameroon" },
                    { 40, "CA", "Canada" },
                    { 41, "029", "Caribbean" },
                    { 42, "KY", "Cayman Islands" },
                    { 43, "CF", "Central African Republic" },
                    { 44, "TD", "Chad" },
                    { 45, "CL", "Chile" },
                    { 32, "VG", "British Virgin Islands" },
                    { 46, "CN", "China" },
                    { 48, "CC", "Cocos (Keeling) Islands" },
                    { 49, "CO", "Colombia" },
                    { 50, "KM", "Comoros" },
                    { 51, "CG", "Congo" },
                    { 52, "CD", "Congo (DRC)" },
                    { 53, "CK", "Cook Islands" },
                    { 54, "CR", "Costa Rica" },
                    { 55, "CI", "Côte d’Ivoire" },
                    { 56, "HR", "Croatia" },
                    { 57, "CU", "Cuba" },
                    { 58, "CW", "Curaçao" },
                    { 59, "CY", "Cyprus" },
                    { 60, "CZ", "Czechia" },
                    { 47, "CX", "Christmas Island" },
                    { 61, "DK", "Denmark" },
                    { 31, "IO", "British Indian Ocean Territory" },
                    { 29, "BW", "Botswana" },
                    { 1, "AF", "Afghanistan" },
                    { 2, "AX", "Åland Islands" },
                    { 3, "AL", "Albania" },
                    { 4, "DZ", "Algeria" },
                    { 5, "AS", "American Samoa" },
                    { 6, "AD", "Andorra" },
                    { 7, "AO", "Angola" },
                    { 8, "AI", "Anguilla" },
                    { 9, "AG", "Antigua and Barbuda" },
                    { 10, "AR", "Argentina" },
                    { 11, "AM", "Armenia" },
                    { 12, "AW", "Aruba" },
                    { 13, "AU", "Australia" },
                    { 30, "BR", "Brazil" },
                    { 14, "AT", "Austria" },
                    { 16, "BS", "Bahamas" },
                    { 17, "BH", "Bahrain" },
                    { 18, "BD", "Bangladesh" },
                    { 19, "BB", "Barbados" },
                    { 20, "BY", "Belarus" },
                    { 21, "BE", "Belgium" },
                    { 22, "BZ", "Belize" },
                    { 23, "BJ", "Benin" },
                    { 24, "BM", "Bermuda" },
                    { 25, "BT", "Bhutan" },
                    { 26, "BO", "Bolivia" },
                    { 27, "BQ", "Bonaire, Sint Eustatius and Saba" },
                    { 28, "BA", "Bosnia and Herzegovina" },
                    { 15, "AZ", "Azerbaijan" },
                    { 128, "LI", "Liechtenstein" },
                    { 62, "DJ", "Djibouti" },
                    { 64, "DO", "Dominican Republic" },
                    { 97, "HT", "Haiti" },
                    { 98, "HN", "Honduras" },
                    { 99, "HK", "Hong Kong SAR" },
                    { 100, "HU", "Hungary" },
                    { 101, "IS", "Iceland" },
                    { 102, "IN", "India" },
                    { 103, "ID", "Indonesia" },
                    { 104, "IR", "Iran" },
                    { 105, "IQ", "Iraq" },
                    { 106, "IE", "Ireland" },
                    { 107, "IM", "Isle of Man" },
                    { 108, "IL", "Israel" },
                    { 109, "IT", "Italy" },
                    { 96, "GY", "Guyana" },
                    { 110, "JM", "Jamaica" },
                    { 112, "JE", "Jersey" },
                    { 113, "JO", "Jordan" },
                    { 114, "KZ", "Kazakhstan" },
                    { 115, "KE", "Kenya" },
                    { 116, "KI", "Kiribati" },
                    { 117, "KR", "Korea" },
                    { 118, "XK", "Kosovo" },
                    { 119, "KW", "Kuwait" },
                    { 120, "KG", "Kyrgyzstan" },
                    { 122, "419", "Latin America" },
                    { 123, "LV", "Latvia" },
                    { 124, "LB", "Lebanon" },
                    { 125, "LS", "Lesotho" },
                    { 111, "JP", "Japan" },
                    { 63, "DM", "Dominica" },
                    { 95, "GW", "Guinea-Bissau" },
                    { 93, "GG", "Guernsey" },
                    { 65, "EC", "Ecuador" },
                    { 66, "EG", "Egypt" },
                    { 67, "SV", "El Salvador" },
                    { 68, "GQ", "Equatorial Guinea" },
                    { 69, "ER", "Eritrea" },
                    { 70, "EE", "Estonia" },
                    { 71, "SZ", "Eswatini" },
                    { 72, "ET", "Ethiopia" },
                    { 73, "150", "Europe" },
                    { 74, "FK", "Falkland Islands" },
                    { 75, "FO", "Faroe Islands" },
                    { 76, "FJ", "Fiji" },
                    { 77, "FI", "Finland" },
                    { 94, "GN", "Guinea" },
                    { 78, "FR", "France" },
                    { 80, "PF", "French Polynesia" },
                    { 81, "GA", "Gabon" },
                    { 82, "GM", "Gambia" },
                    { 83, "GE", "Georgia" },
                    { 84, "DE", "Germany" },
                    { 85, "GH", "Ghana" },
                    { 86, "GI", "Gibraltar" },
                    { 87, "GR", "Greece" },
                    { 88, "GL", "Greenland" },
                    { 89, "GD", "Grenada" },
                    { 90, "GP", "Guadeloupe" },
                    { 91, "GU", "Guam" },
                    { 92, "GT", "Guatemala" },
                    { 79, "GF", "French Guiana" },
                    { 121, "LA", "Laos" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 24, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6845), null, false, null, "Birariya Tryavna" },
                    { 25, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6919), null, false, null, "Mad Panda Brewery Sofia" },
                    { 26, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6992), null, false, null, "Meadly Sofia" },
                    { 27, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(7064), null, false, null, "Metalhead Brewery Burgas" },
                    { 28, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(7271), null, false, null, "Pirinsko Pivo Blagoevgrad" },
                    { 29, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(7376), null, false, null, "Pivoteka Sofia" },
                    { 30, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(7451), null, false, null, "Pivovaren Zavod Kamenitsa Plovdiv" },
                    { 31, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(7525), null, false, null, "Pivovarna 359 Mramor" },
                    { 32, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(7604), null, false, null, "Pivovarna Britos Veliko Tarnovo" },
                    { 33, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(7761), null, false, null, "Pivovarna Zagorka Stara Zagora" },
                    { 34, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(7930), null, false, null, "Rhombus Craft Brewery Pazardzhik" },
                    { 35, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(8028), null, false, null, "Royal Cat Varna" },
                    { 36, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(8110), null, false, null, "Shumensko Pivo Shumen" },
                    { 37, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(8183), null, false, null, "Trima i Dvama Sliven" },
                    { 38, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(8295), null, false, null, "White Stork Beer Company Sofia" },
                    { 39, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(8384), null, false, null, "The Black Sheep Varna" },
                    { 40, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(8459), null, false, null, "Meltum Brewery Lovech" },
                    { 23, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6762), null, false, null, "Lomsko Pivo AD Lom" },
                    { 1, 87, new DateTime(2020, 5, 1, 14, 40, 42, 946, DateTimeKind.Local).AddTicks(1444), null, false, null, "Mythos Breweries" },
                    { 22, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6686), null, false, null, "Kazan Artizan Sofia" },
                    { 20, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6528), null, false, null, "Hills Brewery Perushtitsa" },
                    { 3, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(4722), null, false, null, "Ailyak Sofia" },
                    { 4, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(4903), null, false, null, "Astika Brewery Haskovo" },
                    { 5, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(5136), null, false, null, "Beer Bastards Burgas" },
                    { 6, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(5362), null, false, null, "Beerbox Sofia" },
                    { 7, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(5458), null, false, null, "Beershop-BG Sofia" },
                    { 8, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(5542), null, false, null, "Birariya River Side Sofia" },
                    { 9, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(5623), null, false, null, "Blek Pine Sofia" },
                    { 10, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(5709), null, false, null, "Boliarka Brewery Veliko Tarnovo" },
                    { 11, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(5795), null, false, null, "Bro Beer Sofia" },
                    { 12, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(5879), null, false, null, "Brothers Brew Varna" },
                    { 13, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(5961), null, false, null, "Pivovarnata Burgas" },
                    { 14, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6038), null, false, null, "Can Supply Blagoevgrad" },
                    { 15, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6111), null, false, null, "Cohones Brewery Sofia" },
                    { 16, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6184), null, false, null, "Dorst Sofia" },
                    { 17, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6256), null, false, null, "Dunav Craft Brewery Ruse" },
                    { 18, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6376), null, false, null, "Glarus Craft Brewing Company Varna" },
                    { 19, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6451), null, false, null, "Halbite Sofia" },
                    { 21, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(6607), null, false, null, "Jägerhof Plovdiv" },
                    { 2, 34, new DateTime(2020, 5, 1, 14, 40, 42, 948, DateTimeKind.Local).AddTicks(4262), null, false, null, "Ah! Brew Works Sofia" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholByVolume", "BreweryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "TypeId" },
                values: new object[,]
                {
                    { 2, 6.4000000000000004, 2, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(6756), null, false, null, "Ah! 7 - Mursalski Red Ale", 7 },
                    { 234, 4.0, 32, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(592), null, false, null, "Kronberg", 1 },
                    { 233, 4.0, 32, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(497), null, false, null, "Nazdrave Svetlo", 1 },
                    { 232, 5.5, 32, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(402), null, false, null, "Britos Opusheno", 9 },
                    { 231, 5.0, 32, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(310), null, false, null, "Britos Hoppy Blond", 2 },
                    { 230, 4.5, 32, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(216), null, false, null, "Britos Contintental Lager", 1 },
                    { 229, 4.5, 32, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(117), null, false, null, "Britos", 1 },
                    { 228, 4.5, 31, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(9), null, false, null, "Divo Pivo First Birthday Edition", 2 },
                    { 227, 4.5, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(9881), null, false, null, "Divo Pivo 3rd of March", 2 },
                    { 226, 4.5, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(9777), null, false, null, "Divo Pivo Weiss", 3 },
                    { 225, 4.5999999999999996, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(9678), null, false, null, "Divo Pivo Kapana Ale", 4 },
                    { 224, 6.2000000000000002, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(9577), null, false, null, "Divo Pivo Gaillot", 10 },
                    { 223, 4.5, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(9481), null, false, null, "Na Peikata", 5 },
                    { 222, 4.5, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(9389), null, false, null, "Na Specialnata Peika", 5 },
                    { 221, 4.7000000000000002, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(9299), null, false, null, "Samets", 7 },
                    { 220, 4.5, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(9209), null, false, null, "Kotka & Mishka Session IPA", 5 },
                    { 219, 4.5, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(9120), null, false, null, "Divo Pivo DDH DDH", 4 },
                    { 218, 4.5, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(9023), null, false, null, "Divo Pivo Session IPA", 5 },
                    { 235, 6.5, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(689), null, false, null, "Stolichno Bock", 13 },
                    { 216, 5.5999999999999996, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(8920), null, false, null, "Divo Pivo Red Ale", 7 },
                    { 236, 6.5, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(780), null, false, null, "Stolichno Weiss", 3 },
                    { 238, 6.0, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(974), null, false, null, "Stolichno Amber Pils", 6 },
                    { 255, 6.0, 34, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(6768), null, false, null, "Rhombus Aloha IPA", 5 },
                    { 254, 7.2000000000000002, 34, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(5479), null, false, null, "Rhombus Imperial Porter", 9 },
                    { 253, 7.2000000000000002, 34, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(5378), null, false, null, "Rhombus Dirty", 10 },
                    { 252, 9.3000000000000007, 34, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(5273), null, false, null, "Rhombus Impreial Porter (Barrel Aged)", 9 },
                    { 251, 4.9000000000000004, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(5172), null, false, null, "Ariana Varka7", 1 },
                    { 250, 5.0, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(5062), null, false, null, "Amstel Dark", 8 },
                    { 249, 4.5, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(4814), null, false, null, "Kradetsut na Yabulki Krade I Vishni", 14 },
                    { 248, 4.5, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(4292), null, false, null, "Kradetsut na Yabulki Krade I Slivi", 14 },
                    { 247, 5.0, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(4054), null, false, null, "Zagorka Gold", 1 },
                    { 246, 4.5, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(3805), null, false, null, "Ariana", 1 },
                    { 245, 5.0, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(3152), null, false, null, "Zagorka Spetsialno", 1 },
                    { 244, 4.5, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(1734), null, false, null, "Zagorka Retro", 1 },
                    { 243, 4.7999999999999998, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(1516), null, false, null, "Zagorka IPA", 5 },
                    { 242, 6.0, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(1368), null, false, null, "Zagorka Rezerva", 7 },
                    { 241, 5.5, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(1274), null, false, null, "Ariana Tumno", 8 },
                    { 240, 4.5, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(1176), null, false, null, "Kradetsut na Yabulki Sochna Yabulka", 14 },
                    { 239, 5.5, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(1074), null, false, null, "Stolichno Pale Ale", 4 },
                    { 237, 7.0999999999999996, 33, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(878), null, false, null, "Stolichno Pale Bock", 13 },
                    { 215, 4.5, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(8798), null, false, null, "Divo Pivo HD Limited", 4 },
                    { 214, 4.5, 31, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(8595), null, false, null, "Divo Pivo", 4 },
                    { 213, 4.4000000000000004, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(8433), null, false, null, "Pleven Svetlo", 1 },
                    { 190, 10.5, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(3512), null, false, null, "Metalhead Sweet Stout of Mine Barrel Aged: Jack Daniel's", 10 },
                    { 189, 4.2000000000000002, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(3406), null, false, null, "Metalhead Pleasure and Pain", 3 },
                    { 188, 5.9000000000000004, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(3277), null, false, null, "Metalhead Turbo Lover", 5 },
                    { 187, 7.0999999999999996, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(3165), null, false, null, "Metalhead King Nothing", 5 },
                    { 186, 7.0, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(2868), null, false, null, "Metalhead Supermassive Black IPA", 8 },
                    { 185, 4.5999999999999996, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(1569), null, false, null, "Metalhead Cinn City", 7 },
                    { 184, 6.7000000000000002, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(1328), null, false, null, "Metalhead Headbangers Boil", 5 },
                    { 183, 5.4000000000000004, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(1176), null, false, null, "Metalhead Lickitup", 4 },
                    { 182, 6.9000000000000004, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(905), null, false, null, "Metalhead Your Girlfriend's Girlfriend", 5 },
                    { 181, 10.5, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(727), null, false, null, "Metalhead Sweet Stout of Mine", 10 },
                    { 180, 5.5, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(496), null, false, null, "Metalhead Space Lord", 1 },
                    { 179, 10.0, 26, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(399), null, false, null, "Meadly Zhiva Medovina", 12 },
                    { 178, 12.0, 26, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(295), null, false, null, "Meadly Live Mead With Herbs", 12 },
                    { 177, 13.0, 26, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(163), null, false, null, "Meadly Traditional Mead", 12 },
                    { 176, 11.0, 26, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(9899), null, false, null, "Meadly Sweet Mead", 12 },
                    { 175, 5.5, 25, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(9695), null, false, null, "Mad Panda PsycHOP Therapy", 4 },
                    { 174, 6.5999999999999996, 25, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(9595), null, false, null, "Mad Panda Powder Mafia", 10 },
                    { 191, 3.7999999999999998, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(3618), null, false, null, "Metalhead Running Mild", 4 },
                    { 192, 6.2000000000000002, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(3732), null, false, null, "Metalhead Metalingus", 9 },
                    { 193, 6.5, 27, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(3837), null, false, null, "Metalhead Hop Suey", 5 },
                    { 194, 4.4000000000000004, 28, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(3950), null, false, null, "Pirinsko Svetlo Pivo", 1 },
                    { 212, 9.0, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(8322), null, false, null, "Kamenitza Tvurdo", 11 },
                    { 211, 5.0999999999999996, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(8217), null, false, null, "Kamenitza Live", 1 },
                    { 210, 5.0, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(8110), null, false, null, "Kamenitza Pshenichno", 3 },
                    { 209, 6.0, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(7969), null, false, null, "Kamenitza Tumno", 8 },
                    { 208, 4.9000000000000004, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(6383), null, false, null, "Kamenitza Nefiltrirano", 3 },
                    { 207, 4.0999999999999996, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(5653), null, false, null, "Pleven Svetlo Pivo", 1 },
                    { 206, 5.0, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(5541), null, false, null, "Kamenitza Bialo", 1 },
                    { 205, 4.4000000000000004, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(5417), null, false, null, "Kamenitza Cherveno", 6 },
                    { 256, 5.7999999999999998, 34, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(6976), null, false, null, "Rhombus Weizen IPA", 5 },
                    { 204, 4.0999999999999996, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(5180), null, false, null, "Slavena Svetlo", 1 },
                    { 202, 5.0, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(4854), null, false, null, "Kamenitza Extra", 1 },
                    { 201, 5.0, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(4700), null, false, null, "Kamenitza Lev", 1 },
                    { 200, 5.0, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(4589), null, false, null, "Kamenitza Tamno", 8 },
                    { 199, 4.7999999999999998, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(4481), null, false, null, "Kamenitza Staro Pivo", 11 },
                    { 198, 4.0, 29, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(4376), null, false, null, "Pivoteka Hala", 1 },
                    { 197, 4.7000000000000002, 28, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(4267), null, false, null, "Pirinsko Tumno Pivo", 8 },
                    { 196, 4.4000000000000004, 28, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(4163), null, false, null, "Pirinsko Ledeno", 1 },
                    { 195, 4.4000000000000004, 28, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(4056), null, false, null, "Pirinsko Mlado Pivo", 1 },
                    { 203, 4.4000000000000004, 30, new DateTime(2020, 5, 1, 14, 40, 42, 957, DateTimeKind.Local).AddTicks(5066), null, false, null, "Kamenitza 1881", 1 },
                    { 257, 5.0, 34, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(9271), null, false, null, "Rhombus English Porter", 9 },
                    { 258, 6.2999999999999998, 34, new DateTime(2020, 5, 1, 14, 40, 42, 958, DateTimeKind.Local).AddTicks(9930), null, false, null, "Rhombus Dr. Brettish", 7 },
                    { 259, 6.0, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(353), null, false, null, "Rhombus Dr. Cherry Kriek", 7 },
                    { 309, 7.0, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(8375), null, false, null, "White Stork Cosmic Debris", 5 },
                    { 308, 4.2000000000000002, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(8278), null, false, null, "White Stork Boys Don't Cry-o", 1 },
                    { 307, 9.0, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(8181), null, false, null, "White Stork White Stout", 10 },
                    { 306, 6.7000000000000002, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(8083), null, false, null, "White Stork 1908 Stout", 10 },
                    { 305, 7.0, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(7909), null, false, null, "White Stork Tropikalia IPA", 5 },
                    { 304, 5.0, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(7248), null, false, null, "Trima I Dvama Black Head Stout", 10 },
                    { 303, 5.0, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(7148), null, false, null, "Trima I Dvama Chisto I Prosto", 2 },
                    { 302, 5.0, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(7043), null, false, null, "Trima I Dvama Chai Malko", 2 },
                    { 301, 5.0, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(6938), null, false, null, "Trima I Dvama Unlackee", 7 },
                    { 300, 5.0, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(6791), null, false, null, "Trima I Dvama Ancient Meridian", 2 },
                    { 299, 5.5999999999999996, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(5669), null, false, null, "Trima I Dvama Smoking Hot", 9 },
                    { 298, 4.2000000000000002, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(5561), null, false, null, "Trima I Dvama Janka", 4 },
                    { 297, 7.0, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(5459), null, false, null, "Trima I Dvama Ginger Sucker Happy Ginger Ale", 6 },
                    { 296, 5.0, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(5352), null, false, null, "Trima I Dvama Bloody Muddy", 7 },
                    { 295, 5.5, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(5247), null, false, null, "Trima I Dvama Mashin' Pumpkins", 6 },
                    { 294, 7.0, 37, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(5143), null, false, null, "Trima I Dvama CHIPA", 5 },
                    { 293, 4.2999999999999998, 36, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(5041), null, false, null, "Shumensko Svetlo Pivo", 6 },
                    { 310, 5.5, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(8476), null, false, null, "White Stork Pushing The Limets", 3 },
                    { 311, 3.5, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(8575), null, false, null, "White Stork Rai", 5 },
                    { 312, 5.5, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(8671), null, false, null, "White Stork Original", 4 },
                    { 313, 6.7000000000000002, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(8768), null, false, null, "White Stork Dark Side", 10 },
                    { 331, 4.9000000000000004, 40, new DateTime(2020, 5, 1, 14, 40, 42, 960, DateTimeKind.Local).AddTicks(592), null, false, null, "G-n Xops Pale Ale V2.0", 4 },
                    { 330, 6.0, 40, new DateTime(2020, 5, 1, 14, 40, 42, 960, DateTimeKind.Local).AddTicks(484), null, false, null, "G-n Xops NEIPA V2.0", 5 },
                    { 329, 6.5, 40, new DateTime(2020, 5, 1, 14, 40, 42, 960, DateTimeKind.Local).AddTicks(389), null, false, null, "G-n Xops Coconut Milk Porter", 9 },
                    { 327, 5.0, 39, new DateTime(2020, 5, 1, 14, 40, 42, 960, DateTimeKind.Local).AddTicks(196), null, false, null, "Zlatna Varna Amber", 6 },
                    { 328, 4.9000000000000004, 38, new DateTime(2020, 5, 1, 14, 40, 42, 960, DateTimeKind.Local).AddTicks(288), null, false, null, "Zlatna Varna Pilsner", 11 },
                    { 326, 5.5, 38, new DateTime(2020, 5, 1, 14, 40, 42, 960, DateTimeKind.Local).AddTicks(98), null, false, null, "White Stork Summer", 4 },
                    { 325, 10.0, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(9997), null, false, null, "White Stork Intergalactic DIPA DDH", 5 },
                    { 324, 5.7000000000000002, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(9896), null, false, null, "White Stork Borderless", 6 },
                    { 292, 4.5999999999999996, 36, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(4937), null, false, null, "Shumensko Premium", 1 },
                    { 323, 4.2000000000000002, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(9773), null, false, null, "White Stork Kinky Afro", 11 },
                    { 321, 7.0, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(9578), null, false, null, "White Stork Take Me Somewhere Nice", 5 },
                    { 320, 7.0, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(9479), null, false, null, "White Stork Tropikalia V2.0", 5 },
                    { 319, 4.2000000000000002, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(9377), null, false, null, "White Stork Just a Pilsner", 11 },
                    { 318, 4.2000000000000002, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(9277), null, false, null, "White Stork Into The Galaxy", 11 },
                    { 317, 4.2000000000000002, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(9176), null, false, null, "White Stork Hop Along", 11 },
                    { 316, 4.2000000000000002, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(9074), null, false, null, "White Stork BOOGIEon by Ramsey Hercules", 11 },
                    { 315, 9.0999999999999996, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(8971), null, false, null, "White Stork Mutants", 5 },
                    { 314, 3.6000000000000001, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(8866), null, false, null, "White Stork Sofiiski Weisse", 3 },
                    { 322, 4.2000000000000002, 38, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(9674), null, false, null, "White Stork Dry Hopped House Pilsner", 11 },
                    { 173, 6.7000000000000002, 25, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(9488), null, false, null, "Mad Panda God Gave the Hops", 5 },
                    { 291, 5.2000000000000002, 36, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(4835), null, false, null, "Shumensko", 1 },
                    { 289, 5.0999999999999996, 36, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(4620), null, false, null, "Shumensko Cherveno", 7 },
                    { 276, 4.2000000000000002, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(2225), null, false, null, "Rhombus Pale Ale", 4 },
                    { 275, 5.0, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(2105), null, false, null, "Rhombus Weiss", 3 },
                    { 274, 4.7999999999999998, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(2005), null, false, null, "Rhombus Irish Red", 7 },
                    { 273, 7.2000000000000002, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(1904), null, false, null, "Rhombus Pardon I'm Brut", 5 },
                    { 272, 4.7999999999999998, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(1805), null, false, null, "Rhombus AnimAle", 1 },
                    { 271, 5.0999999999999996, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(1708), null, false, null, "Rhombus Christmas Fever", 10 },
                    { 270, 8.0, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(1611), null, false, null, "Rhombus The Crow", 9 },
                    { 269, 6.2000000000000002, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(1509), null, false, null, "Rhombus Orpheus Gruit", 7 },
                    { 268, 9.1999999999999993, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(1402), null, false, null, "Rhombus Tok i Zhica", 10 },
                    { 267, 3.0, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(1294), null, false, null, "Rhombus Hakuna Matata", 3 },
                    { 266, 6.4000000000000004, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(1183), null, false, null, "Rhombus Mint Nights", 10 },
                    { 265, 4.2000000000000002, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(1069), null, false, null, "Rhombus Lavender Nights", 9 },
                    { 264, 3.8999999999999999, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(959), null, false, null, "Rhombus Violet", 7 },
                    { 263, 6.2999999999999998, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(850), null, false, null, "Rhombus In the Blooming Rye", 5 },
                    { 262, 7.5999999999999996, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(746), null, false, null, "Rhombus Pearl", 6 },
                    { 261, 6.0, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(638), null, false, null, "Rhombus Apfel Strudel", 8 },
                    { 260, 6.0, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(515), null, false, null, "Rhombus Alba - White IPA", 5 },
                    { 277, 5.5, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(2337), null, false, null, "Rhombus Dark Steel", 5 },
                    { 278, 4.5, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(2439), null, false, null, "Rhombus St. Patrick's Beer", 4 },
                    { 279, 3.5, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(2547), null, false, null, "Rhombus Catch the Wave", 5 },
                    { 333, 4.5, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(2659), null, false, null, "Rhombus Pilsner", 11 },
                    { 288, 5.5, 36, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(4514), null, false, null, "Shumensko Tumno", 8 },
                    { 287, 5.5999999999999996, 36, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(4404), null, false, null, "Shumensko Kolektsiya Na Pivovarite Belgiyski Stil", 3 },
                    { 286, 6.2000000000000002, 35, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(4294), null, false, null, "Royal Cat", 3 },
                    { 285, 4.7999999999999998, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(4173), null, false, null, "Rhombus Svetlo", 4 },
                    { 284, 6.5999999999999996, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(4075), null, false, null, "Rhombus Imperial Ale", 10 },
                    { 283, 4.7999999999999998, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(3973), null, false, null, "Rhombus Spetsialno", 7 },
                    { 282, 6.2000000000000002, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(3876), null, false, null, "Rhombus Belgian Blond", 3 },
                    { 281, 5.7000000000000002, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(3772), null, false, null, "Rhombus Flanders Brown Ale Special Selection", 8 },
                    { 290, 5.4000000000000004, 36, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(4727), null, false, null, "Shumnesko Kolektsiya na Pivovarite Cheshki Stil", 11 },
                    { 280, 6.7000000000000002, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(3671), null, false, null, "Rhombus Brown Ale", 8 },
                    { 341, 5.5, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(3464), null, false, null, "Rhombus Breakfast Oatmeal Stout", 10 },
                    { 340, 4.5, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(3364), null, false, null, "Rhombus Kirschtorte", 3 },
                    { 339, 6.2000000000000002, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(3270), null, false, null, "Rhombus Boston Tea Party", 5 },
                    { 338, 6.0, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(3177), null, false, null, "Rhombus Arriba Arriba", 9 },
                    { 337, 5.7999999999999998, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(3079), null, false, null, "Rhombus Black Widow", 5 },
                    { 336, 5.9000000000000004, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(2968), null, false, null, "Rhombus Mart", 6 },
                    { 335, 5.4000000000000004, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(2862), null, false, null, "Rhombus Belona", 5 },
                    { 334, 7.0999999999999996, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(2761), null, false, null, "Rhombus Easter", 8 },
                    { 342, 5.7999999999999998, 34, new DateTime(2020, 5, 1, 14, 40, 42, 959, DateTimeKind.Local).AddTicks(3568), null, false, null, "Rhombus Star Anise Stout", 10 },
                    { 332, 4.5, 40, new DateTime(2020, 5, 1, 14, 40, 42, 960, DateTimeKind.Local).AddTicks(694), null, false, null, "G-n Xops", 4 },
                    { 172, 5.2999999999999998, 25, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(9303), null, false, null, "Mad Panda Cryo Bandit", 4 },
                    { 170, 5.0, 24, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(8734), null, false, null, "Lucs Kehlibar", 8 },
                    { 62, 4.5999999999999996, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(5090), null, false, null, "Schweik Cheshko Pivo", 1 },
                    { 61, 5.0, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(4981), null, false, null, "Boliarka Tumno", 8 },
                    { 60, 6.7000000000000002, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(4839), null, false, null, "Blek Pine IPA Limited Edition", 5 },
                    { 59, 6.2000000000000002, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(4722), null, false, null, "Blek Pine Rye IPA", 5 },
                    { 58, 6.7000000000000002, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(4505), null, false, null, "Blek Pine Sofia Metal Fest IPA", 5 },
                    { 57, 6.2000000000000002, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(4256), null, false, null, "Blek Pine Session", 5 },
                    { 56, 6.4000000000000004, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(4146), null, false, null, "Blek Pine Seriez Peach", 4 },
                    { 55, 7.5999999999999996, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(4003), null, false, null, "Blek Pine Divo Divo", 6 },
                    { 54, 5.7000000000000002, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(3849), null, false, null, "Blek Pine Summer Is Coming - Episode 2", 4 },
                    { 53, 5.4000000000000004, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(3740), null, false, null, "Blek Pine Blanche De Citron", 1 },
                    { 52, 6.5999999999999996, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(3629), null, false, null, "Blek Pine Chilli in the Hills Chipotle Hoppy Stout", 10 },
                    { 51, 9.0999999999999996, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(3522), null, false, null, "Blek Pine Rum Pum Pum", 6 },
                    { 50, 6.5999999999999996, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(3417), null, false, null, "Blek Pine Blek & Red", 10 },
                    { 49, 4.2999999999999998, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(3313), null, false, null, "Blek Pine Sour Session", 5 },
                    { 48, 7.0, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(3210), null, false, null, "Blek Pine New England", 5 },
                    { 47, 6.7000000000000002, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(3101), null, false, null, "Blek Pine WCOS IPA", 5 },
                    { 46, 6.7000000000000002, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(2999), null, false, null, "Blek Pine IPA", 5 },
                    { 63, 4.0999999999999996, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(5196), null, false, null, "Balkansko Svetlo", 1 },
                    { 45, 7.2999999999999998, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(2896), null, false, null, "Blek Pine Pumpking Ale", 7 },
                    { 64, 4.2999999999999998, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(5304), null, false, null, "Boliarka Svetlo", 1 },
                    { 66, 5.0, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(5539), null, false, null, "Kings Premium", 1 },
                    { 83, 5.9000000000000004, 12, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(7914), null, false, null, "Brothers Deutschamerikaner", 5 },
                    { 82, 4.0, 12, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(7801), null, false, null, "Brothers Brew Team Mosaic", 5 },
                    { 81, 5.5, 12, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(7693), null, false, null, "Brothers Brew Team Right As Rain", 6 },
                    { 80, 5.5999999999999996, 12, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(7571), null, false, null, "Brothers Brew Team Make Coffee Great Again", 10 },
                    { 79, 5.0, 11, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(7458), null, false, null, "Bro Beer Importered Pig", 9 },
                    { 78, 3.7999999999999998, 11, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(7316), null, false, null, "Bro Beer Fat Free Pig", 5 },
                    { 77, 4.0999999999999996, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(6815), null, false, null, "Nashensko Svetlo", 1 },
                    { 76, 5.4000000000000004, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(6706), null, false, null, "Boliarka Weiss", 1 },
                    { 75, 4.0999999999999996, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(6599), null, false, null, "Stara Stolitsa Svetlo Pivo", 1 },
                    { 74, 5.0, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(6487), null, false, null, "Boliarka Special", 1 },
                    { 73, 4.0999999999999996, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(6380), null, false, null, "Kehlstein Premium Lager", 1 },
                    { 72, 4.5999999999999996, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(6275), null, false, null, "Peti Okean Jiva Bira", 11 },
                    { 71, 4.0999999999999996, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(6165), null, false, null, "Diana Premium Lager", 1 },
                    { 70, 4.2999999999999998, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(6051), null, false, null, "Boliarka Unpasteurised", 1 },
                    { 69, 3.0, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(5932), null, false, null, "Tsarsko Svetlo", 1 },
                    { 68, 5.0, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(5757), null, false, null, "Boliarka Fort Premium Lager 100% Malt", 1 },
                    { 67, 4.0999999999999996, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(5648), null, false, null, "Boliarka Elba Svetlo Pivo", 1 },
                    { 65, 5.0, 10, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(5414), null, false, null, "Diana Lager", 1 },
                    { 44, 4.7999999999999998, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(2794), null, false, null, "Blek Pine Summer Is Coming", 4 },
                    { 43, 7.7000000000000002, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(2690), null, false, null, "Blek Pine Kokonut Porter", 9 },
                    { 42, 6.7000000000000002, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(2586), null, false, null, "Blek Pine Rauchbier with Cocoa and Blek Pepper", 9 },
                    { 19, 5.0, 4, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(142), null, false, null, "Astika Special", 1 },
                    { 18, 4.4000000000000004, 4, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(37), null, false, null, "Burgasko Svetlo", 1 },
                    { 17, 4.9000000000000004, 4, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(9917), null, false, null, "Astika Lux Premium", 1 },
                    { 16, 4.5, 4, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(9810), null, false, null, "Astika Fine Quality Lager", 1 },
                    { 15, 6.5999999999999996, 3, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(9691), null, false, null, "Ailyak Birthday IPA", 1 },
                    { 14, 6.0, 3, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(9471), null, false, null, "Ailyak ProViotic", 5 },
                    { 13, 6.0, 3, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(9329), null, false, null, "Ailyak Cryo DDH NEIPA", 5 },
                    { 12, 6.0, 3, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(9108), null, false, null, "Ailyak Cryo Mosaic IPA", 5 },
                    { 11, 4.9000000000000004, 2, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(8953), null, false, null, "Ah! 9 - Indian Pale Ale", 4 },
                    { 10, 6.4000000000000004, 2, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(8736), null, false, null, "Ah! 23 - French Apple Cider", 14 },
                    { 9, 4.2000000000000002, 2, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(8479), null, false, null, "Ah! 9 - Kiss My Kvass", 8 },
                    { 8, 8.0, 2, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(8330), null, false, null, "Ah! 13 - Corruption Brown Ale", 8 },
                    { 7, 5.0, 2, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(8112), null, false, null, "Ah! 6 - Funky Janky", 6 },
                    { 6, 7.0, 2, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(7936), null, false, null, "Mr. Habi Benero", 10 },
                    { 5, 5.0, 2, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(7672), null, false, null, "Ah! Sofia Streets", 1 },
                    { 4, 5.2000000000000002, 2, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(7559), null, false, null, "Ah! 3 - Bulgarian Pale Ale", 4 },
                    { 3, 5.0, 2, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(7434), null, false, null, "Ah! 5 - Bad Baba", 1 },
                    { 20, 5.0, 4, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(249), null, false, null, "Haskovo Beck's", 1 },
                    { 34, 5.5999999999999996, 4, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(1741), null, false, null, "Astika Tumno", 8 }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholByVolume", "BreweryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "TypeId" },
                values: new object[,]
                {
                    { 35, 4.4000000000000004, 4, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(1844), null, false, null, "Astika Svetlo", 1 },
                    { 21, 6.7000000000000002, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(351), null, false, null, "Beer Bastards Basi Kefa", 5 },
                    { 41, 6.7000000000000002, 9, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(2466), null, false, null, "Blek Pine Stout", 10 },
                    { 40, 5.2999999999999998, 8, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(2363), null, false, null, "HBH Svetla Jiva Bira", 1 },
                    { 38, 5.5999999999999996, 8, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(2153), null, false, null, "HBH Tumna Jiva Bira", 8 },
                    { 39, 4.7999999999999998, 7, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(2258), null, false, null, "Beershop-BG Gaida", 1 },
                    { 37, 5.0, 6, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(2050), null, false, null, "Beerbox Galleon Premium Lager", 1 },
                    { 36, 4.0, 6, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(1947), null, false, null, "Beerbox Galleon Weiss", 1 },
                    { 33, 5.5, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(1628), null, false, null, "Beer Bastards Toplo Takova", 6 },
                    { 32, 8.0, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(1522), null, false, null, "Beer Bastards Dami Kanyat", 10 },
                    { 84, 4.7000000000000002, 12, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(8021), null, false, null, "Brothers Brew Team Hello, World!", 4 },
                    { 31, 9.6999999999999993, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(1415), null, false, null, "Beer Bastards Tok i Zhica", 10 },
                    { 29, 7.0, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(1208), null, false, null, "Beer Bastards Bone Chance", 9 },
                    { 28, 9.0, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(1101), null, false, null, "Beer Bastards Solo New Garash Cake", 10 },
                    { 27, 4.4000000000000004, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(998), null, false, null, "Beer Bastards Edno Vreme", 11 },
                    { 26, 4.5999999999999996, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(895), null, false, null, "Beer Bastards Bash Maistora", 1 },
                    { 25, 6.5999999999999996, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(790), null, false, null, "Beer Bastards Opasen Char", 5 },
                    { 24, 4.7000000000000002, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(685), null, false, null, "Beer Bastards Freigeist Dirty Flamingo", 4 },
                    { 23, 5.7999999999999998, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(559), null, false, null, "Beer Bastards Faster Bastard", 5 },
                    { 22, 5.2000000000000002, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(454), null, false, null, "Beer Bastards Po-Poleka", 5 },
                    { 30, 4.4000000000000004, 5, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(1311), null, false, null, "Beer Bastards Gusto Maina", 11 },
                    { 85, 8.1999999999999993, 12, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(8126), null, false, null, "Brothers Brew Team Little Princess", 10 },
                    { 86, 7.2000000000000002, 12, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(8239), null, false, null, "Brothers Brew Team Liberation", 5 },
                    { 87, 5.4000000000000004, 13, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(8345), null, false, null, "Veritas Spetsialen Lager", 1 },
                    { 146, 5.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(5137), null, false, null, "Lomsko Amber Beer", 6 },
                    { 145, 5.0, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(5030), null, false, null, "Lomsko Pivo Ubav Pustinyak", 7 },
                    { 144, 5.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(4919), null, false, null, "Vitoshko Lale Hoppy Weiss", 3 },
                    { 143, 4.7999999999999998, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(4813), null, false, null, "Almus Lux", 1 },
                    { 142, 4.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(4709), null, false, null, "Almus Lager", 1 },
                    { 141, 5.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(4601), null, false, null, "Vitoshko Lale", 1 },
                    { 140, 5.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(4495), null, false, null, "Almus Cherveno", 6 },
                    { 139, 5.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(4389), null, false, null, "Almus Tumno", 8 },
                    { 138, 5.7000000000000002, 22, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(4282), null, false, null, "Kazan Artizan Ad Hoc IPA", 5 },
                    { 137, 6.5, 22, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(4176), null, false, null, "Kazan Artizan Stout", 10 },
                    { 136, 5.5, 21, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(4063), null, false, null, "Jägerhof Dunkel Weisse", 3 },
                    { 135, 7.0, 21, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(3958), null, false, null, "Jägerhof Bock", 13 },
                    { 134, 5.2999999999999998, 21, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(3847), null, false, null, "Jägerhof Ale", 6 },
                    { 133, 5.0, 21, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(3743), null, false, null, "Jägerhof Dunkel", 8 },
                    { 132, 5.0, 21, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(3638), null, false, null, "Jägerhof Weiss", 3 },
                    { 131, 4.9000000000000004, 20, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(3528), null, false, null, "Hills Weizen", 3 },
                    { 130, 5.2000000000000002, 20, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(3403), null, false, null, "Hills Single Stout", 10 },
                    { 147, 4.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(5239), null, false, null, "Hmelo Lale", 2 },
                    { 148, 5.0, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(5346), null, false, null, "Lomsko Pivo Blag Pustinyak", 3 },
                    { 149, 5.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(5451), null, false, null, "Lomsko Pivo Shopsko Pivo", 1 },
                    { 150, 7.0, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(5572), null, false, null, "Lomsko Pivo Bash Pustinyak", 1 },
                    { 169, 6.5, 24, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(8534), null, false, null, "Lucs Trevnensko", 8 },
                    { 168, 5.0, 24, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(8414), null, false, null, "Lucs Cherry", 7 },
                    { 167, 5.0, 24, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(8316), null, false, null, "Lucs Plum", 7 },
                    { 166, 3.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(8223), null, false, null, "Optima Svetlo", 11 },
                    { 165, 3.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(8131), null, false, null, "Dunavsko Lager", 1 },
                    { 164, 4.0, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(8041), null, false, null, "Miziya Svetlo", 1 },
                    { 163, 3.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(7948), null, false, null, "Tsarsko Lager", 1 },
                    { 162, 5.0, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(7847), null, false, null, "Almus Special", 1 },
                    { 129, 6.2000000000000002, 20, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(3245), null, false, null, "Hills Smooth Bock", 13 },
                    { 161, 4.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(7746), null, false, null, "Shopsko Svetlo", 1 },
                    { 159, 5.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(7410), null, false, null, "Lomsko Lux", 1 },
                    { 158, 5.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(7176), null, false, null, "Shipka", 1 },
                    { 157, 5.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(7022), null, false, null, "Lomsko Pivo Everyday Luxe", 1 },
                    { 156, 4.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(6891), null, false, null, "Lomsko Pivo Everyday Lager", 1 },
                    { 155, 5.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(6650), null, false, null, "Vitoshko Lale Tumno Pivo", 8 },
                    { 154, 4.5, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(6070), null, false, null, "Vitoshko Lale Pale Ale", 4 },
                    { 153, 6.0, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(5959), null, false, null, "Lomsko Porter", 9 },
                    { 151, 4.0, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(5679), null, false, null, "Lomsko Pivo Pustinyak", 1 },
                    { 160, 4.0, 23, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(7631), null, false, null, "Gredberg", 1 },
                    { 171, 5.0, 24, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(9027), null, false, null, "Lucs Svetlo", 2 },
                    { 128, 3.7999999999999998, 20, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(3015), null, false, null, "Hills Summer Blanche - Session Ale", 3 },
                    { 126, 5.0, 20, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(2712), null, false, null, "Hills Helles Rauch", 9 },
                    { 104, 5.0, 15, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(250), null, false, null, "Cohones Family Jewels", 4 },
                    { 103, 7.0, 15, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(143), null, false, null, "Cohones St. Out", 10 },
                    { 102, 7.5, 15, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(35), null, false, null, "Cohones Holy St. Out", 10 },
                    { 101, 4.2999999999999998, 14, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(9928), null, false, null, "Can Supply Grussberg Pilsner", 11 },
                    { 100, 4.2999999999999998, 14, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(9815), null, false, null, "Can Supply Odesos Svetlo Pivo", 1 },
                    { 99, 4.2999999999999998, 14, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(9701), null, false, null, "Can Supply Odesos Markovo Pivo", 1 },
                    { 98, 4.7000000000000002, 14, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(9589), null, false, null, "Can Supply Brexit Craft Beer", 4 },
                    { 97, 4.0, 14, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(9482), null, false, null, "Can Supply Stobsko Pivo", 11 },
                    { 96, 4.7999999999999998, 13, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(9350), null, false, null, "Veritas Amber", 6 },
                    { 95, 5.2999999999999998, 13, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(9237), null, false, null, "Veritas Weizen", 3 },
                    { 94, 5.5, 13, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(9127), null, false, null, "Veritas Chervena", 7 },
                    { 93, 5.5, 13, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(9021), null, false, null, "Veritas Tumna", 8 },
                    { 92, 5.4000000000000004, 13, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(8909), null, false, null, "Veritas Green Lager", 11 },
                    { 91, 5.2000000000000002, 13, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(8797), null, false, null, "Veritas IPA", 5 },
                    { 90, 5.5, 13, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(8685), null, false, null, "Veritas Schwarz", 9 },
                    { 89, 4.9000000000000004, 13, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(8567), null, false, null, "Burgaska - Pivovarnata Summer Ale", 2 },
                    { 88, 6.2000000000000002, 13, new DateTime(2020, 5, 1, 14, 40, 42, 955, DateTimeKind.Local).AddTicks(8455), null, false, null, "Veritas Single & Single", 2 },
                    { 105, 7.0, 16, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(359), null, false, null, "Dorst Zimen Bok", 8 },
                    { 106, 6.5999999999999996, 16, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(468), null, false, null, "Dorst Hippy Shake", 5 },
                    { 107, 6.0, 16, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(578), null, false, null, "Dorst Pink Future Mosaic", 7 },
                    { 108, 5.7999999999999998, 17, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(689), null, false, null, "Roustchouk Porter", 9 },
                    { 125, 5.0, 19, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(2521), null, false, null, "Halbite Nashto Pivo", 4 },
                    { 152, 5.0, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(5844), null, false, null, "Lomsko Pivo Yak Pustinyak", 1 },
                    { 124, 4.5999999999999996, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(2412), null, false, null, "Glarus London Porter", 9 },
                    { 123, 5.0, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(2309), null, false, null, "Glarus Holy Night", 10 },
                    { 122, 5.0, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(2202), null, false, null, "Glarus Signature Session IPA Mandarina Bavaria", 5 },
                    { 121, 5.0, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(2099), null, false, null, "Glarus Rhodopi Dream", 1 },
                    { 120, 4.7999999999999998, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(1992), null, false, null, "Glarus Fruity & Hazy", 6 },
                    { 119, 4.2000000000000002, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(1884), null, false, null, "Glarus Halo", 4 },
                    { 127, 4.7999999999999998, 20, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(2900), null, false, null, "Hills Pils", 11 },
                    { 118, 4.2000000000000002, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(1777), null, false, null, "Glarus Jester", 4 },
                    { 116, 4.2000000000000002, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(1547), null, false, null, "Glarus Premium Ale", 2 },
                    { 115, 5.0, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(1436), null, false, null, "Glarus Saison", 3 },
                    { 114, 6.5, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(1333), null, false, null, "Glarus Dubbel", 7 },
                    { 113, 4.5999999999999996, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(1229), null, false, null, "Glarus Special English Ale", 4 },
                    { 112, 6.0, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(1123), null, false, null, "Glarus Black Sea IPA", 5 },
                    { 111, 5.0, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(1018), null, false, null, "Glarus Porter", 9 },
                    { 110, 6.2000000000000002, 17, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(909), null, false, null, "Dunav Radetzky", 4 },
                    { 109, 5.7000000000000002, 17, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(798), null, false, null, "Dunav Sans Changement", 1 },
                    { 117, 5.5, 18, new DateTime(2020, 5, 1, 14, 40, 42, 956, DateTimeKind.Local).AddTicks(1670), null, false, null, "Glarus Marzen", 3 },
                    { 1, 5.0, 1, new DateTime(2020, 5, 1, 14, 40, 42, 954, DateTimeKind.Local).AddTicks(1291), null, false, null, "Kaiser", 11 }
                });

            migrationBuilder.InsertData(
                table: "BeersDrank",
                columns: new[] { "UserId", "BeerId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 3, 1 },
                    { 2, 1 },
                    { 1, 1 },
                    { 3, 4 },
                    { 1, 4 },
                    { 2, 4 },
                    { 1, 3 },
                    { 3, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Rating", "TargetBeerId", "Text" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2020, 5, 1, 14, 40, 42, 964, DateTimeKind.Local).AddTicks(5812), null, false, null, "Na Gosho Review-to", 7, 3, "Evalata Pesho mnogo dobra bira" },
                    { 3, 3, new DateTime(2020, 5, 1, 14, 40, 42, 964, DateTimeKind.Local).AddTicks(5970), null, false, null, "Na Tosho Review-to", 8, 2, "Tozi Pesho mnogo hubavi gi pravi." },
                    { 1, 1, new DateTime(2020, 5, 1, 14, 40, 42, 964, DateTimeKind.Local).AddTicks(4136), null, false, null, "Na Pesho Review-to", 10, 1, "Respect!" },
                    { 4, 4, new DateTime(2020, 5, 1, 14, 40, 42, 964, DateTimeKind.Local).AddTicks(6070), null, false, null, "Kaiser nomer edno", 10, 1, "Bira ot butilka ne bqh pil do sq" }
                });

            migrationBuilder.InsertData(
                table: "WishlistBeers",
                columns: new[] { "UserId", "BeerId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 4 },
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_TypeId",
                table: "Beers",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BeersDrank_BeerId",
                table: "BeersDrank",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Breweries_CountryId",
                table: "Breweries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TargetBeerId",
                table: "Reviews",
                column: "TargetBeerId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistBeers_BeerId",
                table: "WishlistBeers",
                column: "BeerId");
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
                name: "BeersDrank");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "WishlistBeers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Breweries");

            migrationBuilder.DropTable(
                name: "BeerTypes");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
