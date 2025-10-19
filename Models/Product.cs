using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_FE.Models // Đảm bảo namespace này khớp với tên project của bạn
{
    public class Product
    {
        public int Id { get; set; }          // Mã định danh duy nhất cho sản phẩm
        public string Name { get; set; }       // Tên sản phẩm (ví dụ: "Adidas Superstar XLG")
        public decimal Price { get; set; }    // Giá sản phẩm (dùng decimal cho tiền tệ)
        public string ImageUrl { get; set; }   // Đường dẫn đến ảnh sản phẩm
        public string Brand { get; set; }      // Thương hiệu con (ví dụ: "Adidas Originals")
        // Bạn có thể thêm các thuộc tính khác sau này (Mô tả, Size, Màu sắc...)
    }
}