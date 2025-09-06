$(document).ready(function () {
    $('#tblData').DataTable({
        "ajax": { "url": "/admin/product/getall" },
        "columns": [
            { data: 'title' },
            { data: 'description' },
            { data: 'isbn' },
            { data: 'author' },
            { data: 'listPrice' },
            { data: 'price' },
            { data: 'price50' },
            { data: 'price100' },
            { data: 'category.name' },
            {
                data: 'id',
                render: function (id) {
                    return `
                        <div class="d-flex gap-2">
                            <a href="/Admin/Product/Edit/${id}" class="btn btn-sm btn-primary">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a onclick="Delete('/Admin/Product/Delete/${id}')" class="btn btn-sm btn-danger">
                                <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>
                    `;
                },
                width: "15%"
            }
        ]
    });
});

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        $('#tblData').DataTable().ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
