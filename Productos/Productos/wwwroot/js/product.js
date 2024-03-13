const btnOpenModalProduct = "#btnOpenModal";
var modalProduct = document.getElementById("modalProducts");
const txtNameProduct = document.getElementById("txtName");
const txtDescProduct = document.getElementById("txtDescription");
const txtPriceProduct = document.getElementById("txtPrice");
const txtQuantityProduct = document.getElementById("txtQuantity");
const listCategories = document.getElementById("listCategories");
const btnSaveChangesProduct = "#btn-saveChangesProducts";

const _modelProduct = {
    Id: 0,
    Name: "",
    Description: "",
    Price: 0,
    Quantity: 0,
    CategoryId: 0
};

function loadProductsAndShow() {
    fetch("/Category/GetCategories")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(categories => {
            listCategories.innerHTML = "";
            categories.value.forEach(category => {
                const option = document.createElement("option");
                option.value = category.id;
                option.textContent = category.name;
                listCategories.appendChild(option);
            });

            ShowProducts(categories.value);
        })
        .catch(error => {
            console.error("Error fetching categories:", error);
        });
}

function ShowProducts(categories) {
    fetch("/Product/GetProducts")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response)
        }).then(responseJson => {
            if (responseJson.value.length > 0) {
                $("#table-products tbody").html("");

                responseJson.value.forEach((product) => {
                    const categoryName = categories.find(c => c.id == product.categoryId).name;

                    const buttonContainer = $("<div>").addClass("btn-group");
                    const editButton = $("<button>").addClass("px-2 py-1 btn btn-outline-warning mx-2 btn-edit-product bi bi-pencil-fill").data("dataProduct", product);
                    const deleteButton = $("<button>").addClass("px-2 py-1 btn btn-outline-danger mx-2 btn-delete-product bi bi-trash").data("dataProduct", product);

                    buttonContainer.append(editButton, deleteButton);

                    $("#table-products tbody").append(
                        $("<tr>").append(
                            $("<td>").addClass("align-middle").text(formatDate(product.createdAt)),
                            $("<td>").addClass("align-middle").text(product.name),
                            $("<td>").addClass("align-middle").text(product.description),
                            $("<td>").addClass("align-middle").text(product.quantity),
                            $("<td>").addClass("align-middle").text(product.price),
                            $("<td>").addClass("align-middle").text(categoryName),
                            $("<td>").addClass("align-middle").append(buttonContainer)
                        )
                    )
                });
            } else {
                $("#table-products tbody").html("");
                $("#table-products tbody").append(
                    $("<tr>").append(
                        $("<td colspan = 6>").text("No Products found!")
                    )
                )
            }
        })
}

function formatDate(dateString) {
    const date = new Date(dateString);
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();
    return `${day}/${month}/${year}`;
}

document.addEventListener("DOMContentLoaded", function () {
    loadProductsAndShow();
}, false);

function ShowModalProduct() {
    $(txtNameProduct).val(_modelProduct.Name);
    $(txtDescProduct).val(_modelProduct.Description);
    $(txtPriceProduct).val(_modelProduct.Price);
    $(txtQuantityProduct).val(_modelProduct.Quantity);
    $(listCategories).val(_modelProduct.Id == 0 ? $("#listCategories option:first").val() : _modelProduct.CategoryId);

    $(modalProduct).modal("show");
}

$(document).on('click', btnOpenModalProduct, function () {
    _modelProduct.Id = 0;
    _modelProduct.Name = "";
    _modelProduct.Description = "";
    _modelProduct.Price = 0;
    _modelProduct.Quantity = 1;
    _modelProduct.CategoryId = 0;

    $(modalProduct).find(".modal-title").text("Create Product");

    ShowModalProduct();
});

$(document).on('click', btnSaveChangesProduct, function (event) {
    event.preventDefault();

    const model = {
        id: _modelProduct.Id,
        name: $(txtNameProduct).val(),
        description: $(txtDescProduct).val(),
        price: parseFloat($(txtPriceProduct).val()),
        quantity: parseInt($(txtQuantityProduct).val()),
        categoryId: parseInt($(listCategories).val())
    };

    if (!model.name || !model.description || isNaN(model.price) || isNaN(model.quantity)) {
        Swal.fire("Error!", "Please fill all fields Correctly.", "error");
    }
    else {
        if (_modelProduct.Id == 0) {
            fetch("/Product/CreateProduct", {
                method: "POST",
                headers: { "Content-type": "application/json; charset:utf-8" },
                body: JSON.stringify(model)
            }).then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            }).then(responseJson => {
                if (responseJson.value) {
                    $(modalProduct).modal("hide");
                    Swal.fire("Ready!", "Create Product Success", "success");
                    loadProductsAndShow();
                }
                else {
                    Swal.fire("Sorry!", "The Product Can't be Create", "error");
                }
            }).catch(error => {
                console.error("Error creating product:", error);
            });
        }
        else {
            fetch("/Product/UpdateProduct", {
                method: "PUT",
                headers: { "Content-type": "application/json; charset:utf-8" },
                body: JSON.stringify(model)
            }).then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            }).then(responseJson => {
                if (responseJson.value) {
                    $(modalProduct).modal("hide");
                    Swal.fire("Ready!", "Update Product Success", "success");
                    loadProductsAndShow();
                }
                else {
                    Swal.fire("Sorry!", "The Product Can't be Update ", "error");
                }
            }).catch(error => {
                console.error("Error Updating product:", error);
            });
        }
    }
});

$(document).on("click", ".btn-delete-product", function () {
    const _product = $(this).data("dataProduct");

    Swal.fire({
        title: "Are you sure?",
        text: `Remove Product: "${_product.name}"`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085D6",
        cancelButtonColor: "#D33",
        confirmButtonText: "Yes, Remove",
        cancelButtonText: "No, Back"
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`/Product/DeleteProduct?id=${_product.id}`, {
                method: "DELETE"
            }).then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            }).then(responseJson => {
                if (responseJson.value) {
                    $(modalProduct).modal("hide");
                    Swal.fire("Ready!", "Remove Product Success", "success");
                    loadProductsAndShow();
                }
                else {
                    Swal.fire("Sorry!", "The Product Can't be Remove ", "error");
                }
            })
        }
    });
});

$(document).on("click", ".btn-edit-product", function () {
    const _product = $(this).data("dataProduct");

    _modelProduct.Id = _product.id;
    _modelProduct.Name = _product.name;
    _modelProduct.Description = _product.description;
    _modelProduct.Price = _product.price;
    _modelProduct.Quantity = _product.quantity;
    _modelProduct.CategoryId = _product.categoryId;

    $(modalProduct).find(".modal-title").text("Edit Product");

    ShowModalProduct();
});