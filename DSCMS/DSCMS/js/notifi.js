$(document).ready(function () {
    var a = '<%=FromServer %>';


    var stack = [];

    stack.push(a);
    stack.push(a);



    var servervalue = stack.pop();


    // ANIMATEDLY DISPLAY THE NOTIFICATION COUNTER.
    $('#noti_Counter')
        .css({ opacity: 0 })
        .text(servervalue)              // ADD DYNAMIC VALUE (YOU CAN EXTRACT DATA FROM DATABASE OR XML).
        .css({ top: '-11px' })
        .animate({ top: '-2px', opacity: 1 }, 500);

    $('#noti_Button').click(function () {

        // TOGGLE (SHOW OR HIDE) NOTIFICATION WINDOW.
        $('#notifications1').fadeToggle('fast', 'linear', function () {
            if ($('#notifications1').is(':hidden')) {
                $('#noti_Button').css('background-color', '#2E467C');
            }
            else $('#noti_Button').css('background-color', '#FFE');        // CHANGE BACKGROUND COLOR OF THE BUTTON.
        });

        $('#noti_Counter').fadeOut('slow');                 // HIDE THE COUNTER.

        return false;
    });

    // HIDE NOTIFICATIONS WHEN CLICKED ANYWHERE ON THE PAGE.
    $(document).click(function () {
        $('#notifications1').hide();

        // CHECK IF NOTIFICATION COUNTER IS HIDDEN.
        if ($('#noti_Counter').is(':hidden')) {
            // CHANGE BACKGROUND COLOR OF THE BUTTON.
            $('#noti_Button').css('background-color', '#2E467C');
        }
    });

    //$('#notifications1').click(function () {
    //    return false;       // DO NOTHING WHEN CONTAINER IS CLICKED.
    //});
});

function redirect() {
    location.href = 'https://forums.asp.net/t/1302692.aspx?Repeater+control+and+hyperlink';
}