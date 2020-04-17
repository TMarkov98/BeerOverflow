using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeerType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
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
                        name: "FK_Breweries_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    IsBanned = table.Column<bool>(nullable: false),
                    BanReason = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
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
                        name: "FK_Beers_BeerType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "BeerType",
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
                        name: "FK_BeersDrank_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                        name: "FK_Reviews_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
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
                        name: "FK_WishlistBeers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BeerType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pale Lager" },
                    { 2, "Blonde Ale" },
                    { 3, "Hefewizen" },
                    { 4, "Pale Ale" },
                    { 5, "IPA" },
                    { 6, "Amber Ale" },
                    { 7, "Irish Red Ale" },
                    { 8, "Brown Ale" },
                    { 9, "Porter" },
                    { 10, "Stout" },
                    { 11, "Pilsner" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 168, "PK", "Pakistan" },
                    { 167, "OM", "Oman" },
                    { 166, "NO", "Norway" },
                    { 165, "MP", "Northern Mariana Islands" },
                    { 164, "KP", "North Korea" },
                    { 158, "NZ", "New Zealand" },
                    { 162, "NU", "Niue" },
                    { 161, "NG", "Nigeria" },
                    { 160, "NE", "Niger" },
                    { 159, "NI", "Nicaragua" },
                    { 169, "PW", "Palau" },
                    { 163, "NF", "Norfolk Island" },
                    { 170, "PS", "Palestinian Authority" },
                    { 176, "PN", "Pitcairn Islands" },
                    { 172, "PG", "Papua New Guinea" },
                    { 173, "PY", "Paraguay" },
                    { 174, "PE", "Peru" },
                    { 175, "PH", "Philippines" },
                    { 157, "NC", "New Caledonia" },
                    { 177, "PL", "Poland" },
                    { 178, "PT", "Portugal" },
                    { 179, "PR", "Puerto Rico" },
                    { 180, "QA", "Qatar" },
                    { 181, "RE", "Réunion" },
                    { 182, "RO", "Romania" },
                    { 183, "RU", "Russia" },
                    { 184, "RW", "Rwanda" },
                    { 171, "PA", "Panama" },
                    { 156, "NL", "Netherlands" },
                    { 151, "MZ", "Mozambique" },
                    { 154, "NR", "Nauru" },
                    { 127, "LI", "Liechtenstein" },
                    { 128, "LT", "Lithuania" },
                    { 129, "LU", "Luxembourg" },
                    { 130, "MO", "Macao SAR" },
                    { 131, "MK", "Macedonia, FYRO" },
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
                    { 185, "BL", "Saint Barthélemy" },
                    { 152, "MM", "Myanmar" },
                    { 153, "NA", "Namibia" },
                    { 155, "NP", "Nepal" },
                    { 186, "KN", "Saint Kitts and Nevis" },
                    { 192, "SM", "San Marino" },
                    { 188, "MF", "Saint Martin" },
                    { 221, "TL", "Timor-Leste" },
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
                    { 241, "VE", "Venezuela" },
                    { 242, "VN", "Vietnam" },
                    { 243, "WF", "Wallis and Futuna" },
                    { 244, "001", "World" },
                    { 245, "YE", "Yemen" },
                    { 246, "ZM", "Zambia" },
                    { 247, "ZW", "Zimbabwe" },
                    { 220, "TH", "Thailand" },
                    { 219, "TZ", "Tanzania" },
                    { 218, "TJ", "Tajikistan" },
                    { 217, "TW", "Taiwan" },
                    { 189, "PM", "Saint Pierre and Miquelon" },
                    { 190, "VC", "Saint Vincent and the Grenadines" },
                    { 191, "WS", "Samoa" },
                    { 126, "LY", "Libya" },
                    { 193, "ST", "São Tomé and Príncipe" },
                    { 194, "SA", "Saudi Arabia" },
                    { 195, "SN", "Senegal" },
                    { 196, "RS", "Serbia" },
                    { 197, "SC", "Seychelles" },
                    { 198, "SL", "Sierra Leone" },
                    { 199, "SG", "Singapore" },
                    { 200, "SX", "Sint Maarten" },
                    { 201, "SK", "Slovakia" },
                    { 187, "LC", "Saint Lucia" },
                    { 202, "SI", "Slovenia" },
                    { 204, "SO", "Somalia" },
                    { 205, "ZA", "South Africa" },
                    { 206, "SS", "South Sudan" },
                    { 207, "ES", "Spain" },
                    { 208, "LK", "Sri Lanka" },
                    { 209, "SH", "St Helena, Ascension, Tristan da Cunha" },
                    { 210, "SD", "Sudan" },
                    { 211, "SR", "Suriname" },
                    { 212, "SJ", "Svalbard and Jan Mayen" },
                    { 213, "SZ", "Swaziland" },
                    { 214, "SE", "Sweden" },
                    { 215, "CH", "Switzerland" },
                    { 216, "SY", "Syria" },
                    { 203, "SB", "Solomon Islands" },
                    { 125, "LR", "Liberia" },
                    { 120, "LA", "Laos" },
                    { 123, "LB", "Lebanon" },
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
                    { 46, "CN", "China" },
                    { 47, "CX", "Christmas Island" },
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
                    { 32, "VG", "British Virgin Islands" },
                    { 31, "IO", "British Indian Ocean Territory" },
                    { 30, "BR", "Brazil" },
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
                    { 60, "CZ", "Czech Republic" },
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
                    { 124, "LS", "Lesotho" },
                    { 61, "DK", "Denmark" },
                    { 63, "DM", "Dominica" },
                    { 95, "GY", "Guyana" },
                    { 96, "HT", "Haiti" },
                    { 97, "HN", "Honduras" },
                    { 98, "HK", "Hong Kong SAR" },
                    { 99, "HU", "Hungary" },
                    { 100, "IS", "Iceland" },
                    { 101, "IN", "India" },
                    { 102, "ID", "Indonesia" },
                    { 103, "IR", "Iran" },
                    { 104, "IQ", "Iraq" },
                    { 105, "IE", "Ireland" },
                    { 106, "IM", "Isle of Man" },
                    { 107, "IL", "Israel" },
                    { 108, "IT", "Italy" },
                    { 109, "JM", "Jamaica" },
                    { 110, "JP", "Japan" },
                    { 111, "JE", "Jersey" },
                    { 112, "JO", "Jordan" },
                    { 113, "KZ", "Kazakhstan" },
                    { 114, "KE", "Kenya" },
                    { 115, "KI", "Kiribati" },
                    { 116, "KR", "Korea" },
                    { 117, "XK", "Kosovo" },
                    { 118, "KW", "Kuwait" },
                    { 119, "KG", "Kyrgyzstan" },
                    { 121, "419", "Latin America" },
                    { 122, "LV", "Latvia" },
                    { 62, "DJ", "Djibouti" },
                    { 93, "GN", "Guinea" },
                    { 94, "GW", "Guinea-Bissau" },
                    { 91, "GT", "Guatemala" },
                    { 64, "DO", "Dominican Republic" },
                    { 65, "EC", "Ecuador" },
                    { 66, "EG", "Egypt" },
                    { 67, "SV", "El Salvador" },
                    { 68, "GQ", "Equatorial Guinea" },
                    { 69, "ER", "Eritrea" },
                    { 70, "EE", "Estonia" },
                    { 71, "ET", "Ethiopia" },
                    { 72, "150", "Europe" },
                    { 73, "FK", "Falkland Islands" },
                    { 74, "FO", "Faroe Islands" },
                    { 75, "FJ", "Fiji" },
                    { 92, "GG", "Guernsey" },
                    { 76, "FI", "Finland" },
                    { 78, "GF", "French Guiana" },
                    { 90, "GU", "Guam" },
                    { 89, "GP", "Guadeloupe" },
                    { 88, "GD", "Grenada" },
                    { 87, "GL", "Greenland" },
                    { 77, "FR", "France" },
                    { 85, "GI", "Gibraltar" },
                    { 86, "GR", "Greece" },
                    { 83, "DE", "Germany" },
                    { 82, "GE", "Georgia" },
                    { 81, "GM", "Gambia" },
                    { 80, "GA", "Gabon" },
                    { 79, "PF", "French Polynesia" },
                    { 84, "GH", "Ghana" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 2, "User" },
                    { 1, "Admin" },
                    { 3, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 4, 1, new DateTime(2020, 4, 17, 20, 55, 35, 182, DateTimeKind.Local).AddTicks(9464), null, false, null, "Na Pesho Leviq Dvor" },
                    { 5, 2, new DateTime(2020, 4, 17, 20, 55, 35, 182, DateTimeKind.Local).AddTicks(9500), null, false, null, "Na Pesho Desniq Dvor" },
                    { 2, 34, new DateTime(2020, 4, 17, 20, 55, 35, 182, DateTimeKind.Local).AddTicks(9254), null, false, null, "Na Pesho Zadniq Dvor" },
                    { 3, 34, new DateTime(2020, 4, 17, 20, 55, 35, 182, DateTimeKind.Local).AddTicks(9415), null, false, null, "Na Pesho Predniq Dvor" },
                    { 1, 87, new DateTime(2020, 4, 17, 20, 55, 35, 178, DateTimeKind.Local).AddTicks(2604), null, false, null, "Mythos Breweries" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BanReason", "CreatedOn", "DeletedOn", "Email", "IsBanned", "IsDeleted", "ModifiedOn", "Password", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 4, 17, 20, 55, 35, 185, DateTimeKind.Local).AddTicks(3481), null, "Pesho@biri.com", false, false, null, "NaPeshoParolata", 2, "Pesho" },
                    { 2, null, new DateTime(2020, 4, 17, 20, 55, 35, 185, DateTimeKind.Local).AddTicks(8154), null, "Gosho@biri.com", false, false, null, "NaGoshoParolata", 2, "Gosho" },
                    { 3, null, new DateTime(2020, 4, 17, 20, 55, 35, 185, DateTimeKind.Local).AddTicks(8337), null, "Tosho@biri.com", false, false, null, "NaToshoParolata", 2, "Tosho" },
                    { 4, null, new DateTime(2020, 4, 17, 20, 55, 35, 185, DateTimeKind.Local).AddTicks(8381), null, "Slavcho@biri.com", false, false, null, "NaSlavchoParolata", 2, "Slavcho" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholByVolume", "BreweryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "TypeId" },
                values: new object[,]
                {
                    { 4, 5.5, 4, new DateTime(2020, 4, 17, 20, 55, 35, 184, DateTimeKind.Local).AddTicks(2344), null, false, null, "Ot Na Pesho Leviq Dvor Birata", 1 },
                    { 5, 4.9000000000000004, 5, new DateTime(2020, 4, 17, 20, 55, 35, 184, DateTimeKind.Local).AddTicks(2384), null, false, null, "Ot Na Pesho Desniq Dvor Birata", 1 },
                    { 2, 7.5, 2, new DateTime(2020, 4, 17, 20, 55, 35, 184, DateTimeKind.Local).AddTicks(2228), null, false, null, "Ot Na Pesho Zadniq Dvor Birata", 1 },
                    { 3, 3.5, 3, new DateTime(2020, 4, 17, 20, 55, 35, 184, DateTimeKind.Local).AddTicks(2294), null, false, null, "Ot Na Pesho Predniq Dvor Birata", 1 },
                    { 1, 5.0, 1, new DateTime(2020, 4, 17, 20, 55, 35, 184, DateTimeKind.Local).AddTicks(861), null, false, null, "Kaiser", 11 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Rating", "TargetBeerId", "Text" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2020, 4, 17, 20, 55, 35, 187, DateTimeKind.Local).AddTicks(8534), null, false, null, "Na Tosho Review-to", 8, 2, "Toz Pesho mnoo hubavi gi prai" },
                    { 2, 2, new DateTime(2020, 4, 17, 20, 55, 35, 187, DateTimeKind.Local).AddTicks(8311), null, false, null, "Na Gosho Review-to", 7, 3, "Evalata Pesho mnoo dobra bira" },
                    { 1, 1, new DateTime(2020, 4, 17, 20, 55, 35, 187, DateTimeKind.Local).AddTicks(5259), null, false, null, "Na Pesho Review-to", 10, 1, "Mnoo dobra bira brat" },
                    { 4, 4, new DateTime(2020, 4, 17, 20, 55, 35, 187, DateTimeKind.Local).AddTicks(8659), null, false, null, "Kaiser nomer edno", 10, 1, "Bira ot butilka ne bqh pil do sq" }
                });

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
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistBeers_BeerId",
                table: "WishlistBeers",
                column: "BeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeersDrank");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "WishlistBeers");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Breweries");

            migrationBuilder.DropTable(
                name: "BeerType");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
