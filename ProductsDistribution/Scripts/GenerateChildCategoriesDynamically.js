var InputModel;
var product__name;
var product__description;
var cut_;
var weight_;
var volume_;
var durability_;
var other_;
var unit_;
var selected_;

function Submit(model) {
    $('#submitButton').click(function (e) {

        //e.preventDefault();
        $.ajax({
            type: 'POST',
            url: "/Product/AddNewProduct",
            data: JSON.stringify(model),
            traditional: true,
            contentType: 'application/json; charset=utf-8',

            success: function (data) {

                
                //alert(data)
                //alert(this.data);

            }

        });
    });
}


$(document).ready(function () {

    // prepare the data
    var source =
        {
            datatype: "json",
            datafields: [
                { name: 'category_id' },
                { name: 'CategoryDTO_parent_id' },
                { name: 'category_name' },
                { name: 'category_description' }
            ],

            id: 'category_id',
            url: '/Product/GetCategoriesTreeView',
            async: false

        };

    // create data adapter.
    var dataAdapter = new $.jqx.dataAdapter(source);

    // perform Data Binding.
    dataAdapter.dataBind();




    // get the tree items. The first parameter is the item's id. The second parameter is the parent item's id. The 'items' parameter represents
    // the sub items collection name. Each jqxTree item has a 'label' property, but in the JSON data, we have a 'text' field. The last parameter
    // specifies the mapping between the 'text' and 'label' fields.

    var records = dataAdapter.getRecordsHierarchy('category_id', 'CategoryDTO_parent_id', 'items', [{ name: 'category_name', map: 'label' }]);

    $('#jqxWidget').jqxTree({ source: records, width: '300px' });

   
    //  var item = $('#jqxWidget').jqxTree('getItem');
    //  alert("Value: " + item.value + "; Text: " + item.label);

         
                //selected_ParentCategory_ = $('#ddlParentCategory').val();
                //selected_ChildCategory_ = $('#ddlChildCategory1 option:selected').val();

        


   // var selectedItem = $('#jqxWidget').jqxTree('selectedItem'); /// get the selected item 
   // var label = selectedItem.label; // get the selected item label

   

    var selectedItem, label;
    $('#jqxWidget').on('select', function (event) {
    //    var htmlElement = event.args.element;
    //    selected_ = $('#jqxWidget').jqxTree('getItem', htmlElement);

        selectedItem = $('#jqxWidget').jqxTree('selectedItem');
       
       // alert(selectedItem.label);

         label = selectedItem.label; 
         
       
    });

   

 


    //$('#jqxWidget').on('select', function (event) {
    //    var args = event.args;
    //    var item = $('#jqxWidget').jqxTree('getItem', args.element);
    //    // alert("Value: " + item.value + "; Text: " + item.label);

    //    selected_= item.value;

    //    alert(selected_);

       

    //}); 
  //  alert(selected_);
    
  

    
  //  Submit(inputModel);
    
});


















//$(document).ready(function () {


    //$('#ddlParentCategory').change(function () {
    //    $.ajax({
    //        type: "post",
    //        url: "/Product/GetAllChildCategories",
    //        data: { categoryName: $('#ddlParentCategory').val() },
    //        datatype: "json",
    //        traditional: true,
    //        success: function (data) {

    //            var child_category = "<select id='ddlChildCategory'>";

    //            child_category = child_category + '<option value=""></option>';
    //            for (var i = 0; i < data.length; i++) {
    //                child_category = child_category + '<option value=' + data[i] + '>' + data[i] + '</option>';
    //            }
    //            child_category = child_category + '</select>';

    //            $('#ddlChildCategory1').html(child_category);


    //            product__name = $('#product_name').val();
    //            product__description = $('#product_description').val();
    //            cut_ = $('#cut').val();
    //            weight_ = $('#weight').val();
    //            volume_ = $('#volume').val();
    //            price_ = $('#price').val();
    //            durability_ = $('#durability').val();
    //            other_ = $('#other').val();
    //            unit_ = $('#unit').val();
    //            selected_ParentCategory_ = $('#ddlParentCategory').val();
    //            selected_ChildCategory_ = $('#ddlChildCategory1 option:selected').val();

    //            inputModel = {
    //                product_name: product__name,
    //                product_description: product__description,
    //                cut: cut_,
    //                weight: weight_,
    //                volume: volume_,
    //                price: price_,
    //                durability: durability_,
    //                other: other_,
    //                unit : unit_,
    //                selected_ParentCategory: selected_ParentCategory_,
    //                selected_ChildCategory: selected_ChildCategory_
    //            };
          



    //        }


    //    });


    //});
   // Submit(inputModel);

//});
