class ItemProxy {

    constructor(moduleID, serviceName) {
        this.serviceName = serviceName;
        var sf = $.ServicesFramework(moduleID);
        this.baseUrl = sf.getServiceRoot(serviceName);
    }

    invoke(method, url, data, callback) {
        $.ajax({
            url: url,
            type: method,
            data: data,
            cache: false,
            success: function (response) {
                callback(true, response);
            }
        })
            .fail(function (xhr) {
                var json = xhr.responseJSON ? xhr.responseJSON : null;
                var jsonError = json && json.error ? json.error : null;

                var message = jsonError
                    || `Request from ${url} failed with status: ${xhr.status}`;

                callback(false, message);
            });
    }

    create(item) {
        this.put(
            this.baseUrl + 'Item/Update',
            {
                item: item
            },
        )
    }

}