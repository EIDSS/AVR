var upload506 = {
    showEditWindow: function (root, id) {
        if (id != 0) {
            var url = bvUrls.getUpload506UpdatePickerUrl({ root: root, id: id });
            bvGrid.showEditWindow(url, 680, 350, EIDSS.BvMessages['title506CasesForUpdate'], "U02");
        }
    },

    showSaveFileDialog : function(id, message) {
        bvDialog.showYesNo(msgConfimation,
            message,
            function () {
                showLoading();
                window.location.href = bvUrls.getUpload506SaveUploadedDataUrl({ id: id });
            },
            function() {
                window.location.href = bvUrls.getupload506CancelUploadedDataUrl({ id: id });
            });
    },

    downloadFile: function (url) {
        var link = document.createElement("a");
        link.download = url;
        link.target = "_blank";

        link.href = url;
        document.body.appendChild(link);
        link.click();

        document.body.removeChild(link);
        delete link;
    },

    markErrorDuplicates: function() {
        var eidssInputs = $("input[name*='EIDSS']");
        
        for (var i = 0; i < eidssInputs.length; i++) {
            var foreignName = "[id='" + eidssInputs[i].name.replace("EIDSS", "506") + "']";
            var foreignInput = $(foreignName);

            if (foreignInput.attr('name')) {
                if (foreignInput.val() !== eidssInputs[i].value) {
                    foreignInput.addClass("errorMessage");
                    //eidssInputs[i].className += " errorMessage";
                    $(eidssInputs[i]).addClass("errorMessage");
                }
            }
        }
    },

    handleDuplicate: function (root, id, duplicateAction) {
        var url = bvUrls.getUpload506UpdatePickerUrl({ root: root, id: id, duplicateAction: duplicateAction });
        
        $.get(url, function (data) {
            $('#WindowBody').html(data);
        });
    },

    getNextDuplicate: function (root, id) {
        upload506.handleDuplicate(root, id, "next");
    },

    getPreviousDuplicate: function (root, id) {
        upload506.handleDuplicate(root, id, "previous");
    },

    setCreateAsNewGetNextDuplicate: function (root, id) {
        upload506.handleDuplicate(root, id, "createasnew");
    },

    setDismissedGetNextDuplicate: function (root, id) {
        upload506.handleDuplicate(root, id, "dismiss");
    },

    setUpdatedGetNextDuplicate: function (root, id) {
        upload506.handleDuplicate(root, id, "update");
    },

    dismissAllDuplicates: function (root) {

        var url = bvUrls.getUpload506DismissAllDuplicatesUrl({ root: root });

        bvDialog.showYesNo(msgConfimation,
            EIDSS.BvMessages['msgUploadFileDismissAll'],
            function () {
                bvPopup.closeDefaultPopup();
                window.location.href = url;
            });
    },

    dismissWhenFinalize: function (root) {

        var url = bvUrls.getUpload506DismissAllDuplicatesUrl({ root: root });

        window.location.href = url;
    },

    finalizeResolveDuplicates: function (root) {

        var url = bvUrls.getUpload506DFinalizeResolveDuplicatesUrl({ root: root });

        window.location.href = url;
    },

    editHumanCase: function (id, listKey, gridName) {
        ActionEditHumanCase(id);
    },
}