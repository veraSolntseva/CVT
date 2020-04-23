$(document).ready(function () {
    var table = $('#contacts-table').DataTable({
        columnDefs: [ //дефолтные настройки столбцов
            { targets: 'dt-no-sort', orderable: false },
            { "className": "dt-center", "targets": [1, 4] }
        ],
        language: { //языковые настройки
            search: '<span>Поиск:</span> _INPUT_',
            searchPlaceholder: '',
            lengthMenu: '<span>Показать:</span> _MENU_',
            processing: "Подождите...",
            info: "Записи с _START_ до _END_ из _TOTAL_ записей",
            infoEmpty: "Записи с 0 до 0 из 0 записей",
            infoFiltered: "(отфильтровано из _MAX_ записей)",
            infoPostFix: "",
            loadingRecords: "Загрузка записей...",
            zeroRecords: "Записи отсутствуют.",
            emptyTable: "В таблице отсутствуют данные",
            paginate: { "first": "Первая", "previous": "Предыдущая", "next": "Следующая", "last": "Последняя" },
            aria: {
                "sortAscending": ": активировать для сортировки столбца по возрастанию",
                "sortDescending": ": активировать для сортировки столбца по убыванию"
            }
        },
        bSortCellsTop: true
    });

    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change clear', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });

    $('.datepicker').datepicker({
        isRTL: false,
        firstDay: 1,
        format: 'dd.mm.yyyy',
        autoclose: true,
        language: 'ru',
        weekStart: 1,
        dateFormat: 'dd.mm.yyyy',
        orientation: "bottom"
    });

    $('#phone_add_btn').on('click', function () {
        var contactsCount = $('#contacts_count').val();

        var elements = '<div class="input-group mb-3 phoneBlock">' +
            '<input type="text" class="form-control phone-inputmask contact_input" data-index="' + contactsCount + '" data-inputmask="\'mask\': \'+7(999)999-99-99\'" placeholder="Номер телефона" name="Contacts[' + contactsCount + '].Value" value="" />' +
            '<div class="input-group-append">' +
            '<button onclick="RemovePhoneBlock(this)" data-index="' + contactsCount + '" class="btn btn-outline-danger remove_phone" type="button"><i class="fa fa-trash-alt"></i></button>' +
            '</div>' +
            '<input name="Contacts[' + contactsCount + '].Id" class="contact_input" value="0" data-index="' + contactsCount + '" hidden />' +
            '<input name="Contacts[' + contactsCount + '].Type" class="contact_input" value="1" data-index="' + contactsCount + '" hidden />' +
            '<input name="Contacts[' + contactsCount + '].PersonId" class="contact_input" value="' + $('#Id').val() + '" data-index="' + contactsCount + '" hidden />';

        var p = $('#phone_container').find('p');

        if (p.length > 0)
            $(p).remove();

        $('#phone_container').append(elements);

        $('#contacts_count').val(parseInt(contactsCount) + 1);

        Inputmask().mask($(".phone-inputmask"));
    })

    $('#skype_add_btn').on('click', function () {
        var contactsCount = $('#contacts_count').val();

        var elements = '<div class="input-group mb-3 skypeBlock">' +
            '<input type="text" class="form-control contact_input" data-index="' + contactsCount + '" placeholder="Skype" name="Contacts[' + contactsCount + '].Value" value="" />' +
            '<div class="input-group-append">' +
            '<button onclick="RemoveSkypeBlock(this)" data-index="' + contactsCount + '" class="btn btn-outline-danger remove_skype" type="button"><i class="fa fa-trash-alt"></i></button>' +
            '</div>' +
            '<input name="Contacts[' + contactsCount + '].Id" class="contact_input" value="0" data-index="' + contactsCount + '" hidden />' +
            '<input name="Contacts[' + contactsCount + '].Type" class="contact_input" value="3" data-index="' + contactsCount + '" hidden />' +
            '<input name="Contacts[' + contactsCount + '].PersonId" class="contact_input" value="' + $('#Id').val() + '" data-index="' + contactsCount + '" hidden />';

        var p = $('#skype_container').children('p');

        if (p.length > 0)
            $(p).remove();

        $('#skype_container').append(elements);

        $('#contacts_count').val(parseInt(contactsCount) + 1);
    })

    $('#email_add_btn').on('click', function () {
        var contactsCount = $('#contacts_count').val();

        var elements = '<div class="input-group mb-3 emailBlock">' +
            '<input type="text" class="form-control contact_input" placeholder="Email" data-index="' + contactsCount + '" name="Contacts[' + contactsCount + '].Value" value="" />' +
            '<div class="input-group-append">' +
            '<button onclick="RemoveEmailBlock(this)" data-index="' + contactsCount + '" class="btn btn-outline-danger remove_email" type="button"><i class="fa fa-trash-alt"></i></button>' +
            '</div>' +
            '<input name="Contacts[' + contactsCount + '].Id" class="contact_input" value="0" data-index="' + contactsCount + '" hidden />' +
            '<input name="Contacts[' + contactsCount + '].Type" class="contact_input" value="2" data-index="' + contactsCount + '" hidden />' +
            '<input name="Contacts[' + contactsCount + '].PersonId" class="contact_input" value="' + $('#Id').val() + '" data-index="' + contactsCount + '" hidden />';

        var p = $('#email_container').children('p');

        if (p.length > 0)
            $(p).remove();

        $('#email_container').append(elements);

        $('#contacts_count').val(parseInt(contactsCount) + 1);
    })

    $('#other_add_btn').on('click', function () {
        var contactsCount = $('#contacts_count').val();

        var elements = '<div class="input-group mb-3 otherBlock">' +
            '<input type="text" class="form-control contact_input" placeholder="Другое" data-index="' + contactsCount + '" name="Contacts[' + contactsCount + '].Value" value="" />' +
            '<div class="input-group-append">' +
            '<button onclick="RemoveOtherBlock(this)" data-index="' + contactsCount + '" class="btn btn-outline-danger remove_other" type="button"><i class="fa fa-trash-alt"></i></button>' +
            '</div>' +
            '<input name="Contacts[' + contactsCount + '].Id" class="contact_input" value="0" data-index="' + contactsCount + '" hidden />' +
            '<input name="Contacts[' + contactsCount + '].Type" class="contact_input" value="4" data-index="' + contactsCount + '" hidden />' +
            '<input name="Contacts[' + contactsCount + '].PersonId" class="contact_input" value="' + $('#Id').val() + '" data-index="' + contactsCount + '" hidden />';

        var p = $('#other_container').children('p');

        if (p.length > 0)
            $(p).remove();

        $('#other_container').append(elements);

        $('#contacts_count').val(parseInt(contactsCount) + 1);
    })

    Inputmask().mask($(".phone-inputmask"));

    $('#confirmModal').on('hidden.bs.modal', function (e) {
        $('#confirmModal').find('.modal-body').children().remove();
    })
});

function RemovePhoneBlock(btn) {
    var div = $(btn).closest('.phoneBlock');
    div.remove();

    ChangeIndexesAndCount($(btn).data('index'));

    if ($('#phone_container').children().length == 0) {
        $('#phone_container').append('<p style="padding-left:30px;"><i>Нет данных</i></p>');
    }
}

function RemoveEmailBlock(btn) {
    var div = $(btn).closest('.emailBlock');
    div.remove();

    ChangeIndexesAndCount($(btn).data('index'));

    if ($('#email_container').children().length == 0) {
        $('#email_container').append('<p style="padding-left:30px;"><i>Нет данных</i></p>');
    }
}

function RemoveSkypeBlock(btn) {
    var div = $(btn).closest('.skypeBlock');
    div.remove();

    ChangeIndexesAndCount($(btn).data('index'));

    if ($('#skype_container').children().length == 0) {
        $('#skype_container').append('<p style="padding-left:30px;"><i>Нет данных</i></p>');
    }
}

function RemoveOtherBlock(btn) {
    var div = $(btn).closest('.otherBlock');
    div.remove();

    ChangeIndexesAndCount($(btn).data('index'));

    if ($('#other_container').children().length == 0) {
        $('#other_container').append('<p style="padding-left:30px;"><i>Нет данных</i></p>');
    }
}

function ChangeIndexesAndCount(btnIndex) {
    $('.contact_input').map(function (i, e) {
        var indexIpt = parseInt($(e).data('index'));

        if (indexIpt > parseInt(btnIndex)) {
            var newNameIpt = String($(e).attr('name')).replace('[' + indexIpt + ']', '[' + String(indexIpt - 1) + ']');
            $(e).attr('name', newNameIpt);
            $(e).attr('data-index', indexIpt - 1);
        }
    });

    var contactsCount = $('#contacts_count').val();
    $('#contacts_count').val(parseInt(contactsCount) - 1);
}

//Открытие диалога при удалении контакта
function OpenModal(button) {
    var personName = $(button).data('personname');
    var personId = $(button).data('personid');

    $('#confirmModal').find('.modal-body').append('<p>Вы уверены, что хотите удалить контакт ' + personName + '?</p>');

    $('#confirmModal').find('.btn-primary').attr('href', '/Home/DeletePerson?personId=' + personId);

    $('#confirmModal').modal('show');
}