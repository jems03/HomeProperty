$(document).ready(function () {
    // For sorting properties
    let propertyList = $('#propertyList');
    let propertyListItem = propertyList.children('li')

    // For pagination rendering
    let propertyPerPage = $('#propertyPerPage');
    let paginationList = $('#pagination');

    // When changing property sort
    $('#sortProperty').on('change', function () {
        const sortValue = $(this).val();

        propertyListItem.sort((a, b) => {
            const propertyA = $(a).data(sortValue);
            const propertyB = $(b).data(sortValue);

            if (sortValue === 'price' || sortValue === 'date') {
                return propertyA > propertyB ? 1 : -1;
            }

            return propertyA.localeCompare(propertyB);
        });

        $.each(propertyListItem, function (idx, item) {
            propertyList.append(item);
        });
    });

    function generatePageNumber() {
        // Pagination function
        let propertyPerPageCount = parseInt(propertyPerPage.val());
        let propertyNum = propertyListItem.length;
        let pageNumber = Math.ceil(propertyNum / propertyPerPageCount);

        // Creation of pagination numbers
        paginationList.empty();
        for (let i = 1; i <= pageNumber; i++) {
            paginationList.append(`<li class="page-item" style="cursor:pointer"><a class="page-link">${i}</a></li>`);
        }

        // Show the first page
        showSelectedPage(1);
    }

    function showSelectedPage(page) {
        // Get the number of properties per page
        let propertyPerPageCount = parseInt(propertyPerPage.val()); // Ensure base 10

        // Hide Property List Item
        propertyListItem.hide();

        // Show the items based on page number
        let start = (page - 1) * propertyPerPageCount;
        let end = start + propertyPerPageCount;

        propertyListItem.slice(start, end).show();

        // Select the current page
        paginationList.find('li').removeClass('active');
        paginationList.find('li').eq(page - 1).addClass('active');
    }

    // Initialization
    generatePageNumber();
    propertyPerPage.on('change', function () {
        generatePageNumber();
    });

    // Handle click events on pagination links
    paginationList.on('click', 'a', function (e) {
        e.preventDefault(); // Prevent default anchor click behavior
        let page = $(this).text(); // Get the page number from the link text
        showSelectedPage(parseInt(page, 10)); // Show the selected page
    });


});