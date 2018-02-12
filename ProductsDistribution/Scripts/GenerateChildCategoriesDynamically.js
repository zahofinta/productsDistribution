var inputModel;
var product__name;
var product__description;
var cut_;
var weight_;
var volume_;
var price_;
var durability_;
var other_;
var selected_ParentCategory_;
var selected_ChildCategory_;

function Submit(model) {
    $('#submitButton').click(function () {


        $.ajax({
            type: 'POST',
            url: "/Product/AddNewProduct",
            data: JSON.stringify(model),
            traditional: true,
            contentType: 'application/json; charset=utf-8',

            success: function (data) {

                alert(this.data);

            }

        });
    });
}

$(document).ready(function () {


    $('#ddlParentCategory').change(function () {
        $.ajax({
            type: "post",
            url: "/Product/GetAllChildCategories",
            data: { categoryName: $('#ddlParentCategory').val() },
            datatype: "json",
            traditional: true,
            success: function (data) {

                var child_category = "<select id='ddlChildCategory'>";

                child_category = child_category + '<option value=""></option>';
                for (var i = 0; i < data.length; i++) {
                    child_category = child_category + '<option value=' + data[i] + '>' + data[i] + '</option>';
                }
                child_category = child_category + '</select>';

                $('#ddlChildCategory1').html(child_category);


                product__name = $('#product_name').val();
                product__description = $('#product_description').val();
                cut_ = $('#cut').val();
                weight_ = $('#weight').val();
                volume_ = $('#volume').val();
                price_ = $('#price').val();
                durability_ = $('#durability').val();
                other_ = $('#other').val();
                selected_ParentCategory_ = $('#ddlParentCategory').val();
                selected_ChildCategory_ = $('#ddlChildCategory1 option:selected').val();

                inputModel = {
                    product_name: product__name,
                    product_description: product__description,
                    cut: cut_,
                    weight: weight_,
                    volume: volume_,
                    price: price_,
                    durability: durability_,
                    other: other_,
                    selected_ParentCategory: selected_ParentCategory_,
                    selected_ChildCategory: selected_ChildCategory_
                };
                //Submit(inputModel);
                //При всяка промяна submit-ва , а трябва само 1 път да submit-ва с последно избраната подкатегория 
                // $('#ddlChildCategory').change(function () {

                //// selected_ChildCategory_ = $('#ddlChildCategory option:selected').last().val();

                //    inputModel = {
                //        product_name: product__name,
                //        product_description: product__description,
                //        cut: cut_,
                //        weight: weight_,
                //        volume: volume_,
                //        price: price_,
                //        durability: durability_,
                //        other: other_,
                //        selected_ParentCategory: selected_ParentCategory_,
                //        selected_ChildCategory: $('#ddlChildCategory option:selected').val()
                //    };
                //    Submit(inputModel);


                // });



            }


        });


    });
    Submit(inputModel);


});
