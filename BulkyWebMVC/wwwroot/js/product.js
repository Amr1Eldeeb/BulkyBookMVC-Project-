
$(document).ready(

    function () {
        loadDatetable()
    });

function loadDatetable() {
   datatable = $('#tblData').DataTable({
       "ajax": { url: '/admin/product/getall' }
   },
       "columns": [
       { data: 'name',"width',"15%" },
       { data: 'position' },
       { data: 'salary' },
       { data: 'office' }
   ]



   );
}


