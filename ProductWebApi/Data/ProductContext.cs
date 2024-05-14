using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ProductWebApi.Data
{
    public class ProductContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            try
            {
                var dbCreator=Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (!dbCreator.CanConnect())
                {
                    dbCreator.Create();
                }
                if (!dbCreator.HasTables())
                {
                    dbCreator.CreateTables();

                    TempleData();
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async void TempleData()
        {
            Categories.Add(new Category
            {
                Ten = "Thuốc Kháng Sinh",
                MoTa = ""
            });
            Categories.Add(new Category
            {
                Ten = "Thuốc Ký Sinh Trùng",
                MoTa = ""
            });
            Categories.Add(new Category
            {
                Ten = "Vắc Xin",
                MoTa = ""
            });
            Categories.Add(new Category
            {
                Ten = "Chế Phẩm Sinh Học",
                MoTa = ""
            });

            Products.Add(new Product
            {
                Ten = "Hanmocla WSP",
                MoTa = "Thuốc bột uống",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/hanmocla%20wsp.jpg",
                ThanhPhan = string.Format($"\"Trong 100g chứa:\r\n               Amoxycillin trihydrate                         10 g\r\n               Acid clavulanic (potassium salf)         2,5 g\r\n               Tá dược vđ                                         100 g\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"Pha thuốc với nước, dùng liên tục 3-5 ngày. Thuốc đã pha chỉ sử dụng trong ngày. - Liều dùng:  Gia súc: 1g/ 10-20 kg TT.                     Gia cầm:   1g/5-10 kg TT. (1g/ 2 lít nước uống hoặc 1g/ kg thức ăn). - Liều phòng: bằng 1/2 liều chữa."),
                Gia = 120000
            });
            Products.Add(new Product
            {
                Ten = "Tylocoli",
                MoTa = "Chuyên trị bệnh đường hô hấp, tiêu hóa.",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/tylocoli%2020.jpg",
                ThanhPhan = string.Format($"\"Mỗi gram chứa:\r\n               Tylosin tartrat                  42 mg\r\n               Colistin                     420 000 IU\r\n               Tá dược vđ                       1 gram\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"Pha với nước uống hoặc trộn thức ăn.        - Bê, nghé, lợn con:                                       1-2 gram/ 10 kg TT/ ngày.        - Chó, mèo:                                                    1 gram/ 5-7 kg TT/ ngày.        - Gia cầm: 1gram/ 3-5 kg TT/ ngày hay pha 1 gram với 0,5 lít nước uống."),
                Gia = 150000
            });
            Products.Add(new Product
            {
                Ten = "TIAMULIN 10%",
                MoTa = "Kháng sinh đặc hiệu nhất chữa CRD, suyễn, hồng lỵ.",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/tiamulin%20100%20g.jpg",
                ThanhPhan = string.Format($"\"Mỗi gói 20 gam chứa:\r\n                   Tiamulin hydrogen fumarat                 2 000 mg\r\n                   Tá dược vđ                                                   20 g\""),
                CongDung = string.Format($"\"- Tiamulin đặc biệt tác dụng mạnh đối với Mycoplasma spp và Treponema spp.\r\n- Đặc trị và phòng bệnh CRD, viêm xoang mũi ở gia cầm; bệnh viêm phổi kết hợp (suyễn), hồng lỵ, viêm khớp ở lợn.\""),
                CachDung = string.Format($"\r\n"),
                Gia = 130000
            });
            Products.Add(new Product
            {
                Ten = "NORFACOLI",
                MoTa = "Đặc trị viêm ruột- ỉa chảy",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/nofacoli%20goi.jpg",
                ThanhPhan = string.Format($"\"Mỗi gói 100 gam có chứa:\r\n                     Norfloxacin                      10 000 mg\r\n                     Vitamin B1                         1 000 mg\r\n                     Vitamin C                           2 500 mg\r\n                     Vitamin K3                            150 mg\r\n                     Niacin                                 2 000 mg\r\n                     Tá dược vđ                          100 gam\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"Pha nước uống hoặc trộn thức ăn. Dùng liên tục 3-5 ngày.        - Lợn, bê, nghé:                                                 1 gam/ 20 kg TT/ ngày.        - Gia cầm: 1 gam/ 20 kg TT/ ngày hoặc 1 gam pha với 1-2 lít nước uống."),
                Gia = 120000
            });
            Products.Add(new Product
            {
                Ten = "Hamenro-C",
                MoTa = "Kháng sinh cho gà, vịt, ngan",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/dsc_0133.jpg",
                ThanhPhan = string.Format($"\"                 Enrofloxacin                  10 gam\r\n                 Vitamin C                       10 gam\r\n                 Tá dược vđ                  100 gam\""),
                CongDung = string.Format($"\"- Phòng và trị các bệnh truyền nhiễm đường hô hấp, tiêu hóa, các bệnh gây do vi khuẩn Gram(-), Gram(+) ở gia cầm.\r\n- Trị phân xanh, phân trắng, ỉa chảy do E.coli, thương hàn, phó thương hàn.\r\n- Chữa CRD, CCRD, viêm túi khí, viêm khớp, vẩy mỏ, khẹc.\""),
                CachDung = string.Format($"Gia cầm: Pha 1 gam với 2 lít nước uống hoặc trộn 1 gam với 1 kg thức ăn. Dùng liên tục 5-7 ngày."),
                Gia = 190000
            });
            Products.Add(new Product
            {
                Ten = "Han-Spicol",
                MoTa = "Kháng sinh phòng bệnh suyễn các bệnh đường hô hấp, tiêu hóa.",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/hanspicol.jpg",
                ThanhPhan = string.Format($"\"Mỗi 1 gam chứa:\r\n                  Spiramycin                                    200 mg\r\n                  Colistin sulfat                      1 000 000 IU\r\n                  Tá dược vđ                                      1 gam\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"- Phòng bệnh:   * Gia cầm: 1-2 g/1 lít nước. Dùng liên tục 5-7 ngày.   * Gia súc: Trên 50 kg: 1 g/15 kg TT.                     Dưới 50 kg: 1 g/5-10 kg TT.                     Dùng liên tục 5-7 ngày. - Chữa bệnh:   * Gia cầm: 2-4 g/1 lít nước uống liên tục 3-5 ngày.   * Gia súc:  Trên 50 kg: 1 g/10 kg TT.                      Dưới 50 kg: 1 g/5 kg TT.                      Dùng liên tục 4-5 ngày."),
                Gia = 160000
            });
            Products.Add(new Product
            {
                Ten = "HAN-NE-SOL",
                MoTa = "Thuốc kháng sinh bột uống",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/han-ne-sol%20100g.jpg",
                ThanhPhan = string.Format($"\"Mỗi gam chứa\r\n             Oxytetracyclin :                            180 mg\r\n             Neomycin :                                    120 mg\r\n             Tá dược vđ:                                     1 gam\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"Liều trung bình: 1 g/10 kg TT./ ngày.  1 g pha với 1 lít nước uống hoặc trộn 1 kg thức ăn. Dùng 3-5 ngày.  Liều phòng bệnh và phòng stress: bằng ½ liều chữa."),
                Gia = 140000
            });
            Products.Add(new Product
            {
                Ten = "LINCOLIS-PLUS",
                MoTa = "Kháng sinh đặc trị viêm phổi, tiêu chảy",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/lincolis-plus.jpg",
                ThanhPhan = string.Format($"\"Mỗi gam chứa:\r\n\r\n                   Lincomycin (dùng dạng lincomycin hydroclorid)              100 mg\r\n\r\n                   Colistin (dùng dạng colistin sulfat)                          1.000.000 IU\r\n\r\n                   Tá dược vđ                                                                      1 gam\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"Pha thuốc với nước uống hoặc trộn thức ăn.  Dùng liên tục 3-5 ngày.            - Lợn, gia súc:                1gam/5-7 kg TT.            - Gà, vịt, ngan, cút:       1 gam/3-5 kg TT."),
                Gia = 140000
            });
            Products.Add(new Product
            {
                Ten = "HANFLOR 4%",
                MoTa = "Đặc trị hen suyễn, tiêu chảy nặng",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/hanflor4tv.jpg",
                ThanhPhan = string.Format($"\r\n"),
                CongDung = string.Format($"\"Gia cầm: Phòng và trị suyễn, tụ huyết trùng, viêm đường hô hấp, tiêu chảy, phân xanh, phân trắng, phân vàng.\r\n\r\nLợn: Đặc trị suyễn lợn, tụ huyết trùng, viêm phổi, hồng lỵ, thương hàn, phó thương hàn.\r\n\r\nTrị các bệnh nhiễm khuẩn kế phát của PRRS ( Bệnh tai xanh).\""),
                CachDung = string.Format($"\"Trộn với thức ăn\r\n\r\nGia cầm: 1-1,5 gam/kg thức ăn.\r\n\r\nDùng liên tục từ 3-5 ngày, có thể nhắc lại sau 2-3 tuần.\r\n\r\nChữa bệnh: 2-3 gam/kg thức ăn. Dùng liên tục từ 3-5 ngày.\r\n\r\nLợn: Phòng bệnh: 1 gam/kg thức ăn.\r\n\r\nChữa bệnh: 2 gam/kg thức ăn.\r\n\r\nDùng liên tục 5 ngày.\r\n\r\nPhòng và trị các bệnh nhiễm khuẩn kế phát của PRRS ( bênh tai xanh), dùng liên tục 7 ngày.\""),
                Gia = 160000
            });
            Products.Add(new Product
            {
                Ten = "Tylosin tartrate",
                MoTa = "Thuốc bột uống Đặc trị nhiễm khuẩn đường hô hấp",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/tylosin-tartrate.jpg",
                ThanhPhan = string.Format($"Mỗi mg Tylosin tartrate chứa ít nhất 800 UI"),
                CongDung = string.Format($"- Chủ trị và phòng các bệnh nhiễm khuẩn đường hô hấp gây do Mycoplasma như: CRD, hen, viêm xoang, vẩy mỏ, sưng đầu ở gà, gà tây. Bệnh suyễn, viêm suyễn, viêm phổi – màng phổi, hồng lỵ, viêm ruột hoại tử, các bệnh xoắn khuẩn, viêm đa khớp ở lợn."),
                CachDung = string.Format($"\"        - Gia cầm:    1 gam pha với 2 lít nước uống hoặc trộn với 1 kg thức ăn.\r\n\r\n        - Lợn:        1 gam pha với 3-4 lít nước uống hoặc trộn với 1 kg thức ăn.\r\n\r\nDùng liên tục 3 -5 ngày.\""),
                Gia = 120000
            });
            Products.Add(new Product
            {
                Ten = "Hanmycin-100",
                MoTa = "Thuốc bột uống",
                categoryId = 1,
                Url = "https://hanvet.com.vn/vn/uploads/HASP/hanmycin.jpg",
                ThanhPhan = string.Format($"\"            Trong 100 gam  chứa:\r\n\r\n                                 Chlortetracyclin ( dạng HCl)                   10 g\r\n\r\n                                 Tá dược vđ                                             100 g\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"\"Pha với nước uống hoặc trộn với thức ăn. Dùng liên tục 5-7 ngày.\r\n\r\nBê, nghé:                  1-2 gam/10kg TT.\r\n\r\nLợn:                          1,5-3 gam/10 kg TT.\r\n\r\nGà:                           2-5 gam/10 kg TT.\r\n\r\nLiều phòng bằng 1/2 liều chữa. Liều tăng trọng bằng 1/10 liều chữa.\""),
                Gia = 160000
            });
            Products.Add(new Product
            {
                Ten = "HAN-OTIC",
                MoTa = "\"Dung dịch nhỏ tai\r\n\r\n\"",
                categoryId = 2,
                Url = "https://hanvet.com.vn/uploads/S%E1%BA%A3n%20ph%E1%BA%A9m/S%E1%BA%A3n%20ph%E1%BA%A9m%20cho%20ch%C3%B3%20m%C3%A8o/Han-Otic.JPG",
                ThanhPhan = string.Format($"\"Trong 1 ml có chứa:\r\n\r\nAcid lactic...............................25 mg\r\n\r\nAcid salicylic .........................1,1 mg\r\n\r\nTá dược vừa đủ .........................1 ml\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"\"Lắc kỹ trước khi sử dụng;\r\n\r\n- Giữ vành tai ngửa lên để ống tai ở vị trí thẳng đứng\r\n\r\n- Nhỏ thuốc vào tai một lượng vừa đủ. Sau đó xoa bóp nhẹ gốc tai để đảm bảo thuốc thấm đều trong ống tai khoảng 1 phút.\r\n\r\n- Dùng bông gòn thấm dung dịch bẩn ở phần trên của vành tai và quanh ống tai.\r\n\r\nVệ sinh 2-3 lần/tuần.\""),
                Gia = 70000
            });

            Products.Add(new Product
            {
                Ten = "Hanmectin Pour-on",
                MoTa = "Thuốc dùng ngoài chuyên dùng đặc trị nội và ngoại ký sinh trùng",
                categoryId = 2,
                Url = "https://www.google.com/imgres?imgurl=http%3A%2F%2Fhanvet.com.vn%2Fvn%2Fuploads%2FHASP%2Fhanmectin-100.jpg&tbnid=us3FuGXTh7WcEM&vet=12ahUKEwif5tv41YaFAxWGka8BHYRQCusQMygBegQIARAx..i&imgrefurl=https%3A%2F%2Fhanvet.com.vn%2Fvn%2Fscripts%2FprodView.asp%3Fidproduct%3D234%26title%3D-page.html&docid=ysCc1Fnu-Wv3kM&w=2344&h=1968&q=H%C3%ACnh%20%E1%BA%A3nh%20Hanmectin%20Pour-on%20hanvet.com&ved=2ahUKEwif5tv41YaFAxWGka8BHYRQCusQMygBegQIARAx",
                ThanhPhan = string.Format($"\"Trong 1 ml có chứa:\r\n\r\n    Ivermectin   5 mg\r\n\r\n    Tá dược vđ 1 ml        \""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"\"Thuốc chỉ định dùng ngoài.\r\n\r\nLiều dùng: 1ml/10kg thể trọng (tương đương với 500 mcg ivermectin/kg thể trọng)\r\n\r\nCách dùng: Rưới thuốc dọc theo sống lưng từ vùng da giữa hai xương bả vai đến khấu đuôi.\r\n\r\nLiệu trình dùng:\r\n\r\nSản phẩm duy trì được tác dụng thuốc lâu dài, cụ thể là:\r\n\r\nDictyocaulus viviparus: tối đa 28 ngày\r\n\r\nOstertagia spp.: đến 21 ngày\r\n\r\nOesophagostomum radiatum: đến 21 ngày\r\n\r\nCooperia spp.: đến 14 ngày\r\n\r\nTrichostrongylus axei: tối đa 14 ngày.\r\n\r\nGiúp kiểm soát ghẻ Chorioptes bovis nhưng không thể loại bỏ hoàn toàn.\r\n\r\nSản phẩm cũng có hiệu quả tác động đến ruồi trâu (Haematobia irritans) trong 35 ngày.\r\n\r\nKhuyến cáo: Bê, nghé được thả trong mùa chăn thả đầu tiên nên được xử lý thuốc ở 3, 8 và 13 tuần sau khi thả, để phát huy tối ưu tác dụng của ivermectin. Điều này giúp bảo vệ gia súc khỏi  ký sinh trùng đường tiêu hóa và giun phổi trong suốt mùa chăn thả.\r\n\r\nLưu ý:\r\n\r\n- Không dùng thuốc khi lông hoặc da trâu, bò bị ướt, hoặc thời tiết dự kiến mưa.\r\n\r\n- Không rưới thuốc lên vùng da bị ghẻ, lở loét, các vết thương hở khác.\r\n\r\n- Trâu, bò sau khu dùng thuốc cần giữ không cho nước tiếp xúc với vị trí rưới thuốc trong vòng 14 ngày.\""),
                Gia = 170000
            });
            Products.Add(new Product
            {
                Ten = "Hanfip-on Plus",
                MoTa = "Dung dịch nhỏ giọt điểm da. Diệt ngoại ký sinh trùng",
                categoryId = 2,
                Url = "https://hanvet.com.vn/uploads/S%E1%BA%A3n%20ph%E1%BA%A9m/S%E1%BA%A3n%20ph%E1%BA%A9m%20cho%20ch%C3%B3%20m%C3%A8o/Hanfip-on%20Plus.jpg",
                ThanhPhan = string.Format($"\"Fipronil                                98 mg\r\n\r\nS)-Methoprene                   88 mg\r\n\r\nTá dược vừa đủ                    1 ml\""),
                CongDung = string.Format($"\"HANFIP-ON Plus là sản phẩm phối hợp của Fipronil và S-Methopren đem lại hiệu quả cao trong tiêu diệt và kiểm soát tất cả các loài bọ chét, ve, chấy, rận và cái ghẻ, cụ thể:\r\n\r\n+ Bọ chét: Diệt hoàn toàn các loài bọ chét ở tất cả các giai đoạn trong vòng đời phát triển, giúp ngăn chặn nguy cơ truyền lây và tái lây nhiễm.\r\n\r\n+ Ve: Tiêu diệt ve ở tất cả các giai đoạn trong vòng đời (ấu trùng, nhộng, và ve trưởng thành) bao gồm ve chó nâu (Rhipicephalus sanguineus), bọ ve chó Mỹ (Dermacentor variabilis), ve Amblyomma americanum, bọ ve chân đen (Ixodes scapularis).\r\n\r\n+ Chấy, rận: Nhanh chóng loại trừ chấy và rận lông ký sinh.\r\n\r\n+ Cái ghẻ: Kiểm soát hiệu quả cái ghẻ ký sinh.\r\n\r\nNhỏ lên da, HANFIP-ON Plus được hấp thu qua da và lưu giữ trong da một thời gian dài (tới 3 tháng) và diệt hầu hết các loại ngoại ký sinh trùng trên da, lông.\""),
                CachDung = string.Format($"\"HANFIP-ON Plus chuyên dùng cho chó từ 8 tuần tuổi trở lên. Chỉ dùng để nhỏ điểm lên da.\r\n\r\nĐặt lọ thuốc lên vùng da giữa hai xương bả vai và nhỏ giọt điểm lên da. Tùy theo cân nặng của chó để dùng với liều lượng tương ứng như sau:\r\n\r\n- Chó dưới 10 kg:0,67 ml\r\n\r\n- Chó 10-20 kg:1,34 ml\r\n\r\n- Chó 20-40 kg:2,68 ml\r\n\r\n- Chó 40-60 kg:4,02 ml\r\n\r\nLiệu trình dùng: Phụ thuộc vào mức độ nhiễm và môi trường, khuyến cáo:\r\n\r\nBọ chét: Nhỏ cách nhau 2-3 tháng.\r\n\r\nVe, bét: Nhỏ 2 lần cách nhau 30 ngày.\r\n\r\nChấy, rận: Thường chỉ nhỏ một lần. Cần thiết lập lại sau mỗitháng.\r\n\r\nGhẻ da: 2 lần cách nhau 3 tuần.\""),
                Gia = 140000
            });
            Products.Add(new Product
            {
                Ten = "VẮC XIN LIÊN CẦU LỢN",
                MoTa = "Vắc xin nhược độc phòng bệnh Liên cầu khuẩn gây ra ở lợn",
                categoryId = 3,
                Url = "https://hanvet.com.vn/uploads/S%E1%BA%A3n%20ph%E1%BA%A9m/v%E1%BA%AFc%20xin/Gia%20s%C3%BAc/anh%20sp%20Vacxin%20lien%20cau%20LON%20DONG%20KHO.png",
                ThanhPhan = string.Format($"\"Mỗi liều vắc xin chứa:\r\n\r\nVi khuẩn Streptococcus suis nhược độc: ≥ 5 x 107 CFU\r\n\r\nChất bổ trợ đông khô vừa đủ\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"\"Dùng nước sinh lý vô khuẩn hoặc dung dịch pha vắc xin đã được làm mát để pha vắc xin.\r\n\r\nCăn cứ vào số liều ghi trên nhãn chai vắc xin để pha sao cho mỗi liều có thể tích 2ml.\r\n\r\nTiêm dưới da hoặc bắp thịt mỗi con 1 liều vắc xin.\""),
                Gia = 165000
            });
            Products.Add(new Product
            {
                Ten = "VẮC XIN TỤ-DẤU-DỊCH TẢ LỢN",
                MoTa = "Vắc xin nhược độc phòng 3 bệnh Tụ huyết trùng, Đóng dấu lợn và Dịch tả lợn",
                categoryId = 3,
                Url = "https://hanvet.com.vn/uploads/S%E1%BA%A3n%20ph%E1%BA%A9m/v%E1%BA%AFc%20xin/Gia%20s%C3%BAc/tam%20li%C3%AAn.png",
                ThanhPhan = string.Format($"\"Mỗi liều vắc xin chứa:\r\nVi khuẩn Pasteurella multocida nhược độc chủng AvPs3:            ≥ 3´108 CFU\r\nVi khuẩn Erysipelothrix rhusiopathiae nhược độc chủng VR2:        ≥ 107 CFU\r\nVi rút dịch tả lợn nhược độc (chủng C) nuôi cấy trên tế bào:       ≥103 TCID50\r\nChất ổn định vừa đủ.\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"\"Sử dụng dịch pha vắc xin đi kèm đã được làm mát để pha vắc xin.\r\nDùng bơm tiêm vô khuẩn hút một phần dịch (2-3ml) trong lọ dịch pha vắc xin, bơm vào lọ vắc xin để hòa tan viên vắc xin đông khô.\r\nLắc đều cho lọ vắc xin tan hoàn toàn và đồng nhất. Sau đó, hút toàn bộ lượng vắc xin đã hòa tan chuyển sang lọ dịch pha vắc xin tương ứng và lắc đều.\r\nTiêm bắp thịt hoặc dưới da, mỗi con một liều vắc xin tương đương 2ml.\r\nTiêm phòng cho lợn theo chỉ dẫn sau:\r\n\r\nVới lợn thịt: tiêm phòng cho lợn lúc 2 tháng tuổi\r\nVới lợn hậu bị và lợn nái: tiêm phòng trước khi phối giống 2 – 3 tuần\r\nVới lợn đực giống: Tiêm phòng định kỳ 6 tháng 1 lần\""),
                Gia = 105000
            });
            Products.Add(new Product
            {
                Ten = "VẮC XIN GIẢ DẠI",
                MoTa = "Vắc xin nhược độc phòng bệnh Giả dại cho lợn",
                categoryId = 3,
                Url = "https://hanvet.com.vn/uploads/S%E1%BA%A3n%20ph%E1%BA%A9m/v%E1%BA%AFc%20xin/Gia%20s%C3%BAc/gia%20dai.png",
                ThanhPhan = string.Format($"\"Mỗi liều vắc xin chứa ít nhất 104.0 TCID50 Vi rút Giả dại nhược độc chủng Bartha K61\r\n\r\nChất ổn định đông khô: vừa đủ\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"\"Dùng nước sinh lý vô khuẩn hoặc dịch pha vắc xin đã được làm mát để pha vắc xin.\r\n\r\nCăn cứ vào số liều ghi trên chai vắc xin để pha sao cho mỗi liều có thể tích 2 ml. Tiêm bắp sau hốc tai mỗi con một liều vắc xin.\r\n\r\nTiêm phòng cho lợn theo chỉ dẫn sau:\r\n\r\nLợn thịt: tiêm phòng mũi thứ nhất lúc 1 tháng tuổi, tiêm nhắc lại sau 3 - 4 tuần để có miễn dịch vững chắc.\r\n\r\nLợn nái hậu bị: tiêm phòng trước khi phối giống 2-3 tuần.\r\n\r\nLợn nái mang thai: tiêm phòng trước khi sinh 3 - 4 tuần.\r\n\r\nLợn đực giống: tiêm phòng 1 năm 3 lần.\""),
                Gia = 140000
            });
            Products.Add(new Product
            {
                Ten = "VẮC XIN PED",
                MoTa = "Vắc xin vô hoạt nhũ dầu phòng bệnh tiêu chảy do vi rút PED gây ra ở lợn",
                categoryId = 3,
                Url = "https://hanvet.com.vn/uploads/S%E1%BA%A3n%20ph%E1%BA%A9m/v%E1%BA%AFc%20xin/Gia%20s%C3%BAc/%E1%BA%A3nh%20Hop%20chai%20Ped.png",
                ThanhPhan = string.Format($"\"Mỗi liều vắc xin chứa:\r\nKháng nguyên vi rút PED trước vô hoạt: ≥ 105.0TCID50\r\nBổ trợ nhũ dầu Montanide ISA 201 : vừa đủ 2ml\""),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"\"Để lọ vắc xin ra ngoài nhiệt độ phòng 10 – 15 phút cho hết lạnh.\r\nLắc đều lọ vắc xin trước khi sử dụng.\r\nTiêm cho lợn liều 2ml/con vào bắp sau tai.\r\nTiêm phòng cho lợn theo chỉ dẫn sau\r\nLợn nái hậu bị:\r\nTiêm mũi 01: khi được lựa chọn làm nái hậu bị\r\nTiêm mũi 02: 3 tuần sau khi tiêm mũi 01.\r\nLợn nái mang thai:\r\nTiêm mũi 01: trước khi sinh 5 tuần\r\nTiêm mũi 02: trước khi sinh 2 tuần.\""),
                Gia = 180000
            });
            Products.Add(new Product
            {
                Ten = "Vắc xin tai xanh",
                MoTa = "Vắc xin nhược độc đông khô được phân lập từ các chủng gây bệnh tai xanh (PRRS) tại Việt Nam",
                categoryId = 3,
                Url = "https://hanvet.com.vn/uploads/S%E1%BA%A3n%20ph%E1%BA%A9m/v%E1%BA%AFc%20xin/Gia%20s%C3%BAc/tai%20xanh.jpg",
                ThanhPhan = string.Format($"\r\n"),
                CongDung = string.Format($"\r\n"),
                CachDung = string.Format($"\"- Dùng dung dịch pha vắc xin hoặc nước sinh lý mặn vô khuẩn đã được làm mát để pha.\r\n- Căn cứ vào số liện ghi trên lọ vắc xin để pha sao cho mỗi liều có thể tích 1 ml. Tiêm bắp thịt sau tai, mỗi con một liều vắc xin.\r\nTiêm phòng cho lợn theo chỉ dẫn sau:\r\n- Lợn con từ 3 tuần tuổi, tiêm 1 liều/con. Tiêm nhắc lại sau 4 tháng theo chỉ định.\r\n- Lợn nái trước khi phối giống 2 tuần, tiêm 1 liều/con.\""),
                Gia = 130000
            });

            await this.SaveChangesAsync();

        }
    }
}
