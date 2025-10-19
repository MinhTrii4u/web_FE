// Sử dụng $(document).ready() của jQuery
$(document).ready(function () {

    // --- PHẦN TÌM KIẾM (Giữ nguyên) ---
    const searchButton = document.getElementById('search-button');
    const searchInput = document.getElementById('search-input');
    if (searchButton && searchInput) {
        searchButton.addEventListener('click', function () {
            const searchTerm = searchInput.value.trim();
            if (searchTerm) {
                alert('Bạn đang tìm kiếm: ' + searchTerm);
            } else {
                alert('Vui lòng nhập từ khóa tìm kiếm!');
            }
        });
        searchInput.addEventListener('keypress', function (event) {
            if (event.key === 'Enter') {
                searchButton.click();
            }
        });
    }

    // --- PHẦN THÊM VÀO GIỎ HÀNG TỪ TRANG CHỦ (Giữ nguyên) ---
    const addToCartButtons = document.querySelectorAll('.add-to-cart-btn');
    const cartCountSpan = document.querySelector('.cart-count');
    if (cartCountSpan) {
        let cartItemCount = parseInt(cartCountSpan.textContent) || 0;
        addToCartButtons.forEach(button => {
            button.addEventListener('click', function () {
                cartItemCount++;
                cartCountSpan.textContent = cartItemCount;
                // alert('Đã thêm sản phẩm vào giỏ hàng!'); // Tạm ẩn
            });
        });
    }

    // --- LOGIC SLIDER BANNER (Giữ nguyên) ---
    let currentSlide = 0;
    const slides = $('.slide');
    const dots = $('.dot');
    const totalSlides = slides.length;
    let slideInterval;
    function showSlide(index) { /* ... code showSlide ... */ }
    function nextSlide() { /* ... code nextSlide ... */ }
    function prevSlide() { /* ... code prevSlide ... */ }
    function startSlider() { /* ... code startSlider ... */ }
    function stopSlider() { /* ... code stopSlider ... */ }
    if (slides.length > 0) {
        // Gán sự kiện cho nút và dấu chấm
        $('.slider-control.next').on('click', function () { stopSlider(); nextSlide(); startSlider(); });
        $('.slider-control.prev').on('click', function () { stopSlider(); prevSlide(); startSlider(); });
        $('.dot').on('click', function () { stopSlider(); showSlide($(this).data('slide')); startSlider(); });
        // Khởi động
        showSlide(0);
        startSlider();
        $('.slider').on('mouseenter', stopSlider).on('mouseleave', startSlider);
    }

    // === LOGIC MỚI CHO TRANG GIỎ HÀNG ===

    // Hàm định dạng tiền tệ (Ví dụ: 1000000 -> 1.000.000₫)
    function formatCurrency(number) {
        return number.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
    }

    // Hàm tính tổng tiền giỏ hàng
    function updateCartTotal() {
        let total = 0;
        // Lặp qua tất cả các dòng sản phẩm trong bảng giỏ hàng
        $('#cartTable tbody tr').each(function () {
            const $row = $(this);
            // Tìm ô chứa tổng tiền của dòng đó
            const itemTotalText = $row.find('.item-total').text();
            // Chuyển text thành số (loại bỏ '₫', '.', và khoảng trắng)
            const itemTotal = parseFloat(itemTotalText.replace(/[.₫\s]/g, '').replace(',', '.')) || 0;
            total += itemTotal;
        });
        // Cập nhật tổng tiền hiển thị
        $('#totalPrice').text(formatCurrency(total));
    }

    // Xử lý sự kiện bấm nút TĂNG số lượng (+)
    // Sử dụng event delegation để bắt sự kiện cho các nút được thêm sau này (nếu có)
    $('#cartTable').on('click', '.increase-qty', function () {
        const $button = $(this);
        const $row = $button.closest('tr'); // Tìm dòng (tr) chứa nút vừa bấm
        const $quantitySpan = $row.find('.item-quantity'); // Tìm ô hiển thị số lượng
        const $itemTotalCell = $row.find('.item-total'); // Tìm ô hiển thị tổng tiền của item
        const priceText = $row.find('td').eq(2).text(); // Lấy giá đơn vị từ cột thứ 3 (index 2)

        // Lấy số lượng hiện tại và giá đơn vị
        let quantity = parseInt($quantitySpan.text());
        const price = parseFloat(priceText.replace(/[.₫\s]/g, '').replace(',', '.')) || 0;

        // Tăng số lượng (có thể thêm giới hạn nếu muốn)
        quantity++;
        $quantitySpan.text(quantity); // Cập nhật số lượng hiển thị

        // Tính lại tổng tiền cho sản phẩm này và cập nhật hiển thị
        const newItemTotal = quantity * price;
        $itemTotalCell.text(formatCurrency(newItemTotal));

        // Tính lại tổng tiền toàn bộ giỏ hàng
        updateCartTotal();
    });

    // Xử lý sự kiện bấm nút GIẢM số lượng (-)
    $('#cartTable').on('click', '.decrease-qty', function () {
        const $button = $(this);
        const $row = $button.closest('tr');
        const $quantitySpan = $row.find('.item-quantity');
        const $itemTotalCell = $row.find('.item-total');
        const priceText = $row.find('td').eq(2).text();

        let quantity = parseInt($quantitySpan.text());
        const price = parseFloat(priceText.replace(/[.₫\s]/g, '').replace(',', '.')) || 0;

        // Chỉ giảm nếu số lượng lớn hơn 1
        if (quantity > 1) {
            quantity--;
            $quantitySpan.text(quantity);

            const newItemTotal = quantity * price;
            $itemTotalCell.text(formatCurrency(newItemTotal));

            updateCartTotal();
        } else {
            // Nếu số lượng là 1 mà bấm giảm, có thể hỏi người dùng muốn xóa không
            // Hoặc đơn giản là không làm gì cả
            // alert('Số lượng tối thiểu là 1.');
        }
    });

    // Xử lý sự kiện bấm nút XÓA
    $('#cartTable').on('click', '.remove-btn', function () {
        const $button = $(this);
        // Hỏi xác nhận trước khi xóa (tùy chọn)
        if (confirm('Bạn có chắc muốn xóa sản phẩm này khỏi giỏ hàng?')) {
            const $row = $button.closest('tr');
            $row.remove(); // Xóa dòng khỏi bảng

            // Cập nhật lại tổng tiền
            updateCartTotal();

            // Cập nhật lại số lượng trên icon giỏ hàng ở header (nếu cần)
            // Bạn có thể viết thêm code để tính tổng số lượng item còn lại và cập nhật cartCountSpan
        }
    });

    // Tính tổng tiền lần đầu khi tải trang giỏ hàng
    if ($('#cartTable').length > 0) { // Chỉ chạy nếu đang ở trang giỏ hàng
        updateCartTotal();
    }
    // === KẾT THÚC LOGIC TRANG GIỎ HÀNG ===

}); // Kết thúc $(document).ready()