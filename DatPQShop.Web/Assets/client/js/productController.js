var homeconfig = {
    pageSize: 1,
    pageIndex: 1,
}
var productController = {
    init: function () {
        productController.loadData();
    },
    loadData: function () {
        var id = $('#categoryId').data('id');
        $.ajax({
            url: '/Product/LoadProduct',
            type: 'GET',
            dataType: 'json',
            data: {
                id: id,
                page: homeconfig.pageIndex,
                pageSize: homeconfig.pageSize
            },
            success: function (response) {

                var data = response.Items;
                var html = '';
                var template = $('#data-template').html();
                $.each(data, function (i, item) {
                    if (item.PromotionPrice == null) {
                        item.PromotionPrice = item.Price;
                        item.Price = null;
                    }
                    html += Mustache.render(template, {
                        Name: item.Name,
                        Image: item.Image,
                        Description: item.Description,
                        PromotionPrice: item.PromotionPrice,
                        Price: item.Price
                    });

                });
                html += "<div class=\"clearfix\"></div>";
                $('#products').html(html);
                productController.paging(response.TotalCount, function () {
                    productController.loadData();
                });


            }
        });
    },
    paging: function (totalRow, callback) {
        var totalPage = Math.ceil(totalRow / homeconfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: "Đầu",
            next: "Tiếp",
            last: "Cuối",
            prev: "Trước",
            visiblePages: 10,
            onPageClick: function (event, page) {
                homeconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }

}
productController.init();