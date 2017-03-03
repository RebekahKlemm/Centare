function MyCheckInViewModel(model) {
    var self = this;

    self.pageSize = ko.observable(10);
    self.checkIns = ko.observableArray(model.CheckIns);

    self.checkInPage = ko.computed(function () {
        return self.checkIns().slice(0, self.pageSize());
    });
}