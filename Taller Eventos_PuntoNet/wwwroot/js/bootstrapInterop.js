window.bootstrapInterop = {
    showModal: function (id) {
        var modalElement = document.querySelector(id);
        var modal = new bootstrap.Modal(modalElement);
        modal.show();
    },
    hideModal: function (id) {
        var modalElement = document.querySelector(id);
        var modal = bootstrap.Modal.getInstance(modalElement);
        if (modal) modal.hide();
    }
};
