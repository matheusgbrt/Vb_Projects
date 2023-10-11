function getTableData(sender, args, key) { // Recebe sender e parametros do evento -> devolve valor da chave chamada
    var tableView = sender.get_masterTableView()
    try {
        var itemIndex = args.get_commandArgument()
    }
    catch (error) {
        var itemIndex = args.get_itemIndexHierarchical()
    }

    var KeyVal = tableView.get_dataItems()[itemIndex].getDataKeyValue(key)
    return KeyVal
}
function onPopUpShowing(sender, args) {
    args.get_popUp().className += " popUpEditForm";
};

function PaginaDetalhes(sender, args) {
    var KeyVal = getTableData(sender, args, "IDMovies")

    var params = new URLSearchParams({
        var1: KeyVal,
    })
    var url = "Detalhes.aspx/?"
    var final = url + params.toString()
    window.open(final, "_blank")
}


var preventCommand = true;

function gridCommand(sender, args) {
    var commandName = args.get_commandName();

    if (commandName == 'Delete') { // Trata do comando delete; Ordem de eventos: Recebe Key, cancela o envio do evento ao servidor, chama janela de confirmação, caso seja confirmado envia o comando ao servidor.
        var itemIndex = args.get_commandArgument();
        var tableView = args.get_tableView();
        var KeyVal = tableView.get_dataItems()[itemIndex].getDataKeyValue("id");
        var confirmMessage = "Tem certeza que deseja deletar a entrada de id=  " + KeyVal + "?";
        if (preventCommand) {
            args.set_cancel(preventCommand);
            radconfirm(confirmMessage, confirmCallBackFn, 300, 150, null, "Confirmação"); // Mensagem de confirmacao, chamada callback para disparar comando, width, height, obj enviador(?), título.
        }

        function confirmCallBackFn(arg) {
            if (arg) {
                preventCommand = false;
                tableView.fireCommand(commandName, itemIndex);
            }
        }
    }
}
