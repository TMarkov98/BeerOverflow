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
                    AlcoholByVolume = table.Column<double>(nullable: false),
                    Likes = table.Column<int>(nullable: false)
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
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Likes = table.Column<int>(nullable: false)
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
                    { 169, "PK", "Pakistan" },
                    { 168, "OM", "Oman" },
                    { 167, "NO", "Norway" },
                    { 166, "MP", "Northern Mariana Islands" },
                    { 165, "MK", "North Macedonia" },
                    { 159, "NI", "Nicaragua" },
                    { 163, "NF", "Norfolk Island" },
                    { 162, "NU", "Niue" },
                    { 161, "NG", "Nigeria" },
                    { 160, "NE", "Niger" },
                    { 170, "PW", "Palau" },
                    { 164, "KP", "North Korea" },
                    { 171, "PS", "Palestinian Authority" },
                    { 177, "PN", "Pitcairn Islands" },
                    { 173, "PG", "Papua New Guinea" },
                    { 174, "PY", "Paraguay" },
                    { 175, "PE", "Peru" },
                    { 176, "PH", "Philippines" },
                    { 158, "NZ", "New Zealand" },
                    { 178, "PL", "Poland" },
                    { 179, "PT", "Portugal" },
                    { 180, "PR", "Puerto Rico" },
                    { 181, "QA", "Qatar" },
                    { 182, "RE", "Réunion" },
                    { 183, "RO", "Romania" },
                    { 184, "RU", "Russia" },
                    { 185, "RW", "Rwanda" },
                    { 172, "PA", "Panama" },
                    { 157, "NC", "New Caledonia" },
                    { 151, "MZ", "Mozambique" },
                    { 155, "NP", "Nepal" },
                    { 127, "LY", "Libya" },
                    { 128, "LI", "Liechtenstein" },
                    { 129, "LT", "Lithuania" },
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
                    { 156, "NL", "Netherlands" },
                    { 140, "MR", "Mauritania" },
                    { 142, "YT", "Mayotte" },
                    { 143, "MX", "Mexico" },
                    { 144, "FM", "Micronesia" },
                    { 145, "MD", "Moldova" },
                    { 146, "MC", "Monaco" },
                    { 147, "MN", "Mongolia" },
                    { 148, "ME", "Montenegro" },
                    { 149, "MS", "Montserrat" },
                    { 150, "MA", "Morocco" },
                    { 186, "BL", "Saint Barthélemy" },
                    { 152, "MM", "Myanmar" },
                    { 153, "NA", "Namibia" },
                    { 154, "NR", "Nauru" },
                    { 141, "MU", "Mauritius" },
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
                    { 220, "TH", "Thailand" },
                    { 219, "TZ", "Tanzania" },
                    { 218, "TJ", "Tajikistan" },
                    { 190, "PM", "Saint Pierre and Miquelon" },
                    { 191, "VC", "Saint Vincent and the Grenadines" },
                    { 126, "LR", "Liberia" },
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
                    { 188, "LC", "Saint Lucia" },
                    { 203, "SI", "Slovenia" },
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
                    { 204, "SB", "Solomon Islands" },
                    { 125, "LS", "Lesotho" },
                    { 120, "KG", "Kyrgyzstan" },
                    { 123, "LV", "Latvia" },
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
                    { 60, "CZ", "Czechia" },
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
                    { 124, "LB", "Lebanon" },
                    { 61, "DK", "Denmark" },
                    { 63, "DM", "Dominica" },
                    { 95, "GW", "Guinea-Bissau" },
                    { 96, "GY", "Guyana" },
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
                    { 110, "JM", "Jamaica" },
                    { 111, "JP", "Japan" },
                    { 112, "JE", "Jersey" },
                    { 113, "JO", "Jordan" },
                    { 114, "KZ", "Kazakhstan" },
                    { 115, "KE", "Kenya" },
                    { 116, "KI", "Kiribati" },
                    { 117, "KR", "Korea" },
                    { 118, "XK", "Kosovo" },
                    { 119, "KW", "Kuwait" },
                    { 121, "LA", "Laos" },
                    { 122, "419", "Latin America" },
                    { 62, "DJ", "Djibouti" },
                    { 93, "GG", "Guernsey" },
                    { 94, "GN", "Guinea" },
                    { 91, "GU", "Guam" },
                    { 64, "DO", "Dominican Republic" },
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
                    { 92, "GT", "Guatemala" },
                    { 76, "FJ", "Fiji" },
                    { 78, "FR", "France" },
                    { 90, "GP", "Guadeloupe" },
                    { 89, "GD", "Grenada" },
                    { 88, "GL", "Greenland" },
                    { 87, "GR", "Greece" },
                    { 77, "FI", "Finland" },
                    { 85, "GH", "Ghana" },
                    { 86, "GI", "Gibraltar" },
                    { 83, "GE", "Georgia" },
                    { 82, "GM", "Gambia" },
                    { 81, "GA", "Gabon" },
                    { 80, "PF", "French Polynesia" },
                    { 79, "GF", "French Guiana" },
                    { 84, "DE", "Germany" }
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
                    { 4, 1, new DateTime(2020, 4, 15, 15, 52, 24, 918, DateTimeKind.Local).AddTicks(9117), null, false, null, "Na Pesho Leviq Dvor" },
                    { 5, 2, new DateTime(2020, 4, 15, 15, 52, 24, 918, DateTimeKind.Local).AddTicks(9135), null, false, null, "Na Pesho Desniq Dvor" },
                    { 2, 34, new DateTime(2020, 4, 15, 15, 52, 24, 918, DateTimeKind.Local).AddTicks(9012), null, false, null, "Na Pesho Zadniq Dvor" },
                    { 3, 34, new DateTime(2020, 4, 15, 15, 52, 24, 918, DateTimeKind.Local).AddTicks(9094), null, false, null, "Na Pesho Predniq Dvor" },
                    { 1, 87, new DateTime(2020, 4, 15, 15, 52, 24, 917, DateTimeKind.Local).AddTicks(596), null, false, null, "Mythos Breweries" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BanReason", "CreatedOn", "DeletedOn", "Email", "IsBanned", "IsDeleted", "ModifiedOn", "Password", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 4, 15, 15, 52, 24, 919, DateTimeKind.Local).AddTicks(8952), null, "Pesho@biri.com", false, false, null, "NaPeshoParolata", 2, "Pesho" },
                    { 2, null, new DateTime(2020, 4, 15, 15, 52, 24, 920, DateTimeKind.Local).AddTicks(491), null, "Gosho@biri.com", false, false, null, "NaGoshoParolata", 2, "Gosho" },
                    { 3, null, new DateTime(2020, 4, 15, 15, 52, 24, 920, DateTimeKind.Local).AddTicks(564), null, "Tosho@biri.com", false, false, null, "NaToshoParolata", 2, "Tosho" },
                    { 4, null, new DateTime(2020, 4, 15, 15, 52, 24, 920, DateTimeKind.Local).AddTicks(586), null, "Slavcho@biri.com", false, false, null, "NaSlavchoParolata", 2, "Slavcho" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholByVolume", "BreweryId", "CreatedOn", "DeletedOn", "IsDeleted", "Likes", "ModifiedOn", "Name", "TypeId" },
                values: new object[,]
                {
                    { 4, 5.5, 4, new DateTime(2020, 4, 15, 15, 52, 24, 919, DateTimeKind.Local).AddTicks(4617), null, false, 40, null, "Ot Na Pesho Leviq Dvor Birata", 1 },
                    { 5, 4.9000000000000004, 5, new DateTime(2020, 4, 15, 15, 52, 24, 919, DateTimeKind.Local).AddTicks(4637), null, false, 40, null, "Ot Na Pesho Desniq Dvor Birata", 1 },
                    { 2, 7.5, 2, new DateTime(2020, 4, 15, 15, 52, 24, 919, DateTimeKind.Local).AddTicks(4553), null, false, 40, null, "Ot Na Pesho Zadniq Dvor Birata", 1 },
                    { 3, 3.5, 3, new DateTime(2020, 4, 15, 15, 52, 24, 919, DateTimeKind.Local).AddTicks(4596), null, false, 40, null, "Ot Na Pesho Predniq Dvor Birata", 1 },
                    { 1, 5.0, 1, new DateTime(2020, 4, 15, 15, 52, 24, 919, DateTimeKind.Local).AddTicks(3617), null, false, 40000, null, "Kaiser", 11 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "DeletedOn", "IsDeleted", "Likes", "ModifiedOn", "Name", "Rating", "TargetBeerId", "Text" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2020, 4, 15, 15, 52, 24, 920, DateTimeKind.Local).AddTicks(4067), null, false, 5, null, "Na Tosho Review-to", 8, 2, "Toz Pesho mnoo hubavi gi prai" },
                    { 2, 2, new DateTime(2020, 4, 15, 15, 52, 24, 920, DateTimeKind.Local).AddTicks(4040), null, false, 2, null, "Na Gosho Review-to", 7, 3, "Evalata Pesho mnoo dobra bira" },
                    { 1, 1, new DateTime(2020, 4, 15, 15, 52, 24, 920, DateTimeKind.Local).AddTicks(3839), null, false, 250, null, "Na Pesho Review-to", 10, 1, "Mnoo dobra bira brat" },
                    { 4, 4, new DateTime(2020, 4, 15, 15, 52, 24, 920, DateTimeKind.Local).AddTicks(4088), null, false, 2, null, "Kaiser nomer edno", 10, 1, "Bira ot butilka ne bqh pil do sq" }
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
