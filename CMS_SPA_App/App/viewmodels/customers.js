define(['plugins/http', 'knockout','plugins/router'], function (http, ko, router) {
    
    var customersViewModel = {
        customers: ko.observableArray([]),
        sortFirstName: sortFirstName,                
        activate: activate,
        moreInfo: moreInfo,
        currentPage: ko.observable(1),
        perPage: 5,
        pagedItems: ko.observableArray([]),
        pager: pager,
        nextPage: nextPage,
        nextPageEnabled: nextPageEnabled,
        previousPage: previousPage,
        previousPageEnabled: previousPageEnabled
                
    }
    return customersViewModel;

    function activate() {        
        return getCustomers();
    }

    function moreInfo(customer) {
        router.navigate('customer/' + customer.Person_Id);
    }
 
    function sortFirstName() {
        customersViewModel.customers().sort(function (left, right) { return left.First_Name == right.First_Name ? 0 : (left.First_Name < right.First_Name ? -1 : 1) });        
    }

    function getCustomers() {
        return http.get("/api/customers").then(function (customers) {
            customersViewModel.customers(customers);
            pager();
        });
    }
    
    
    function pager() {
        return ko.computed(function () {
            var pg = customersViewModel.currentPage();
            var start = customersViewModel.perPage * (pg - 1);
            var end = start + customersViewModel.perPage;
            console.log(start);
            console.log(end);
            customersViewModel.pagedItems(customersViewModel.customers().slice(start, end));
        }, customersViewModel);
    }

    function nextPage() {
        console.log(customersViewModel.previousPageEnabled());
        if (nextPageEnabled()) {            
            customersViewModel.currentPage(customersViewModel.currentPage() + 1);
            console.log("Page: " + customersViewModel.currentPage());
            //pager();
        }
    };

    function nextPageEnabled() {        
        return customersViewModel.customers().length > customersViewModel.perPage * customersViewModel.currentPage();        
    }

    function previousPage() {
        console.log(customersViewModel.previousPageEnabled());
        if (customersViewModel.previousPageEnabled()){
            customersViewModel.currentPage(customersViewModel.currentPage() - 1);
            console.log("Page: " + customersViewModel.currentPage());
            //pager();
        }
    }

    function previousPageEnabled() {
        return customersViewModel.currentPage() > 1;
    }
});
