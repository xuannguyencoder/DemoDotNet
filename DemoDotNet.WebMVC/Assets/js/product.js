var product = {
    init: function () {
        product.regEvents();
    },
    regEvents: function () {
        $('#btnAdd').off('click').on('click', function (e) {
            $("#btnAdd").on("click", function () {
                var fileImage = $("#fileImage").get(0);
                var files = fileImage.files;

                var formData = new FormData();
                for (var i = 0; i < files.length; i++) {
                    formData.append(files[i].name, files[i]);
                }
                formData.append("Name", $("#Name").val());
                formData.append("Price", $("#Price").val());
                formData.append("Discription", $("#Discription").val());
                formData.append("Status", $("#Status").val());
                formData.append("CategoryID", $("#CategoryID").val());
                $.ajax({
                    url: '/Admin/Product/Create',
                    type: 'POST',
                    data: formData,
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/admin/san-pham";
                        };
                    },
                });
            });
        });
        $('#btnUpdate').off('click').on('click', function (e) {
            $("#btnUpdate").on("click", function () {
                var fileImage = $("#fileImage").get(0);
                var files = fileImage.files;

                var formData = new FormData();
                for (var i = 0; i < files.length; i++) {
                    formData.append(files[i].name, files[i]);
                }
                formData.append("ID", $("#ID").val());
                formData.append("Name", $("#Name").val());
                formData.append("Price", $("#Price").val());
                formData.append("Discription", $("#Discription").val());
                formData.append("Status", $("#Status").val());
                formData.append("CategoryID", $("#CategoryID").val());
                $.ajax({
                    url: '/Admin/Product/Edit',
                    type: 'POST',
                    data: formData,
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/admin/san-pham";
                        };
                    },
                });
            });
        });
        $('.update_status').off('click').on('click', function (e) {
            e.preventDefault(); //xóa dấu # trên thẻ link
            $.ajax({
                url: '/Admin/Product/UpdateStatus',
                data: {
                    ID : $(this).data('id')
                },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    window.location.href = "/admin/san-pham";
                }
            });
        });
        $('.sweet-confirm').off('click').on('click', function (e) {
            Swal.fire({
                title: 'Bạn có chắc chắc muốn xóa?',
                text: "Bạn sẽ không thể khôi phục nếu xóa",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Xóa',
                cancelButtonText: 'Hủy'
            }).then((result) => {
                if (result.isConfirmed) {
                    e.preventDefault(); //xóa dấu # trên thẻ link
                    $.ajax({
                        url: '/Admin/Product/Delete',
                        data: {
                            ID : $(this).data('id')
                        },
                        dataType: 'json',
                        type: 'POST',
                        success: function (res) {
                            window.location.href = "/admin/san-pham";
                        }
                    });
                }
            })
        });
    }
}
product.init();
