$(document).ready(function() {
    var notificationContainer = $('<div id="notificationContainer"></div>').css({
        position: 'fixed',
        top: 20,
        right: 20,
        zIndex: 9999
    });
    $('body').append(notificationContainer);

    $.ajax({
        url: '/Notifications/GetNotifications',
        type: 'GET',
        dataType: 'json',
        success: function(notifications) {
            var unseenNotifications = notifications.filter(function(notification) {
                return notification.isSeen === false;
            });

            if (unseenNotifications.length > 0) {
                unseenNotifications.reverse().forEach(function(notification) {
                    var toast = $(`
                        <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                            <div class="toast-header">
                                <strong class="mr-auto">Notification</strong>
                                <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="toast-body">
                                ${notification.message}
                            </div>
                        </div>
                    `);
                    toast.appendTo(notificationContainer).toast('show');
                    setTimeout(function() {
                        toast.toast('hide');
                    }, 10000);
                    toast.on('click', function() {
                        $.ajax({
                            url: '/Notifications/MarkAsSeen',
                            type: 'POST',
                            data: { id: notification.id },
                            success: function() {
                                toast.toast('dispose');
                            }
                        });
                    });
                });
            }
        }
    });
});