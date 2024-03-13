const btnOpenModalCategory = "#btnOpenModal";
var modalCategory = document.getElementById("modalCategory");
const txtNameCategory = document.getElementById("txtName");
const txtIdCategory = document.getElementById("txtId");
const btnSaveChangesCategory = "#btn-saveChangescategories";

const _modelCategory = {
    Id: 0,
    Name: ""
};
function ShowCategories() {
    fetch("/Category/GetCategories")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response)
        }).then(responseJson => {
            if (responseJson.value.length > 0) {
                $("#table-categories tbody").html("");

                responseJson.value.forEach((category) => {
                    const buttonContainer = $("<div>").addClass("btn-group");
                    const editButton = $("<button>").addClass("px-2 py-1 btn btn-outline-warning mx-2 btn-edit-category bi bi-pencil-fill").data("dataCategory", category);
                    const deleteButton = $("<button>").addClass("px-2 py-1 btn btn-outline-danger mx-2 btn-delete-category bi bi-trash").data("dataCategory", category);

                    buttonContainer.append(editButton, deleteButton);

                    $("#table-categories tbody").append(
                        $("<tr>").append(
                            $("<td>").addClass("align-middle").text(category.id),
                            $("<td>").addClass("align-middle").text(category.name),
                            $("<td>").addClass("align-middle").append(buttonContainer)
                        )
                    )
                });
            } else {
                $("#table-categories tbody").html("");
                $("#table-categories tbody").append(
                    $("<tr>").append(
                        $("<td colspan = 6>").text("No Categories found!")
                    )
                )
            }
        })
}

document.addEventListener("DOMContentLoaded", function () {
    ShowCategories();
}, false);

function ShowModalCategory() {
    $(txtIdCategory).val(_modelCategory.Id);
    $(txtNameCategory).val(_modelCategory.Name);

    $(modalCategory).modal("show");
}

$(document).on('click', btnOpenModalCategory, function () {
    _modelCategory.Id = 0;
    _modelCategory.Name = "";

    $(modalCategory).find(".modal-title").text("Create Category");

    ShowModalCategory();
});

$(document).on('click', btnSaveChangesCategory, function (event) {
    event.preventDefault();

    const model = {
        id: _modelCategory.Id,
        name: $(txtNameCategory).val()
    };

    if (!model.name) {
        Swal.fire("Error!", "Please fill all fields Correctly.", "error");
    }
    else {
        if (_modelCategory.Id == 0) {
            fetch("/Category/CreateCategory", {
                method: "POST",
                headers: { "Content-type": "application/json; charset:utf-8" },
                body: JSON.stringify(model)
            }).then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            }).then(responseJson => {
                if (responseJson.value) {
                    $(modalCategory).modal("hide");
                    Swal.fire("Ready!", "Create Category Success", "success");
                    ShowCategories();
                }
                else {
                    Swal.fire("Sorry!", "The Product Can't be Create", "error");
                }
            }).catch(error => {
                console.error("Error creating product:", error);
            });
        }
        else {
            fetch("/Category/UpdateCategory", {
                method: "PUT",
                headers: { "Content-type": "application/json; charset:utf-8" },
                body: JSON.stringify(model)
            }).then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            }).then(responseJson => {
                if (responseJson.value) {
                    $(modalCategory).modal("hide");
                    Swal.fire("Ready!", "Update Category Success", "success");
                    ShowCategories();
                }
                else {
                    Swal.fire("Sorry!", "The Category Can't be Update ", "error");
                }
            }).catch(error => {
                console.error("Error Updating Category:", error);
            });
        }
    }
});

$(document).on("click", ".btn-delete-category", function () {
    const _category = $(this).data("dataCategory");

    Swal.fire({
        title: "Are you sure?",
        text: `Remove Category: "${_category.name}", remember that deleting this category will delete the associated products`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085D6",
        cancelButtonColor: "#D33",
        confirmButtonText: "Yes, Remove",
        cancelButtonText: "No, Back"
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`/Category/DeleteCategory?id=${_category.id}`, {
                method: "DELETE"
            }).then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            }).then(responseJson => {
                if (responseJson.value) {
                    $(modalCategory).modal("hide");
                    Swal.fire("Ready!", "Remove Category Success", "success");
                    ShowCategories();
                }
                else {
                    Swal.fire("Sorry!", "The Category Can't be Remove ", "error");
                }
            })
        }
    });
});

$(document).on("click", ".btn-edit-category", function () {
    const _category = $(this).data("dataCategory");

    _modelCategory.Id = _category.id;
    _modelCategory.Name = _category.name;

    $(modalCategory).find(".modal-title").text("Edit Category");

    ShowModalCategory();
});