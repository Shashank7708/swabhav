
$(document).ready(function () {
	fnCategoryList();
})
function fnCategoryList() {
	debugger;
	var iabc = $('#h1Html');
	iabc.html("hello world");
	var CategoryData = $('#tbodyCategory');
	CategoryData.empty();
	$.ajax({
		type: "POST",
		url: "/Category/GetAllCategory",
		data: { id: 4 },
		dataType: "JSON",
		success: function (result) {
			debugger;
			console.log(result);
			$.each(result.categoryList, function (index, i) {
				CategoryData.append(
					`<tr>
			<td>${i.id}</td>
			<td>${i.name}</td>
			<td>${i.mainCategory}</td>
			<td>${i.displayOrder}</td>
			<td>${i.createdOn}</td>
			<td>${i.createdBy}</td>
			<td>
		<a href="#" class="btn btn-warning" onclick="getById(`+i.id+`)" >Edit</a>
		<a href="#" class="btn btn-danger" onclick="deleteCategory(`+i.id+`)">Delete</a>
	</td>
			</tr>`
				);
			});
			$('#btnUpdate').hide();
			$('#btnAdd').show();
		},
		error: function (req, status, error) {

		}
	});

}
function Add() {
	debugger;
	var obj = {
		Name: $('#name').val(),
		MainCategory: $('#mainCategory').val(),
		DisplayOrder: $('#displayOrder').val(),
		CreatedBy: 'Admin',
		CreatedOn: new Date(),
	};
	$.ajax({
		type: "Post",
		url: "/Category/Add",
		data: JSON.stringify(obj),
		contentType: "application/json;charset=utf-8",
		success: function (result) {
			console.log(result);
			$('#myModal').modal('hide');
			fnCategoryList();
		},
		error: function (errormessage) {
			console.log(errormessage)
		}
	})
}

function getById(id) {

	$.ajax({
		type: "GET",
		url: "/Category/GetById/" + id,
		contentType: "application/json;charset=utf-8",
		datatype: "json",
		success: function (result) {
			debugger;
			$('#name').val(result.name),
				$('#Id').val(result.id);
				$('#mainCategory').val(result.mainCategory),
				$('#displayOrder').val(result.displayOrder)
			$('#myModal').modal('show');
			$('#btnUpdate').show();
			$('#btnAdd').hide();
		},
		error: function (error) {
			console.log(error)
		}
	})
}
function Update() {
	var obj = {
		Id: $('#id').val(),
		Name: $('#name').val(),
		MainCategory: $('#mainCategory').val(),
		DisplayOrder: $('#displayOrder').val(),
		CreatedBy: 'Admin',
		CreatedOn: new Date()
	};
	debugger;
	$.ajax({
		type: "POST",
		url: "/Category/Update",
		data: JSON.stringify(obj),
		contentType: 'application/json;charset=utf-8',
		success: function (result) {
			debugger;
			console.log(result);
			clearInputs();
			fnCategoryList;
		},
		error: function (err) {
			console.log(err);
		}
	})
}

function clearInputs() {
	$('#Id').val(''),
		$('#name').val('');
	$('#mainCategory').val('');
	$('#displayOrder').val('');
	
}
function deleteCategory(id) {
	$.ajax({
		type: "GET",
		url: "/Category/Delele/"+id,
		success: function (result) {
			console.log(result);
			fnCategoryList;
		},
		error: function (err) {
			console.log(err)
		}
	})
}
function clearTextBox() {
	$('#myModal').modal('toggle'); }