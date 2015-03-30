define(['plugins/http', 'knockout'], function (http, ko) {

    var customerViewModel = {
        customer: { First_Name: null, Last_Name: null, Email: null, Language: null, Country: null },
        activate: activate
    }
    return customerViewModel;

    function activate(id) {
        //console.log(arguments);
        return getCustomer(id);
    }

    function getCustomer(id) {
        return http.get("/api/customers/" + id).then(function (customer) {
            customerViewModel.customer = customer;
        });
    }
});
