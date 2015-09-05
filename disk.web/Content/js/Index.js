	var zTree;
var demoIframe;

var setting = {
    view: {
        dblClickExpand: false,
        showLine: true,
        selectedMulti: false
    },
    data: {
        simpleData: {
            enable:true,
            idKey: "id",
            pIdKey: "pId",
            rootPId: ""
        }
    },
    callback: {
        onClick: treeClick
    }
};

//添加标签页
function treeClick(treeNode) {
    var subtitle = treeNode.text;
    var url = treeNode.file;
    if (url == '' || url == undefined)return;
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url),
            //href:url,
            closable: true,
            overflow: 'no',
            width: $('#mainPanle').width() - 10,
            height: $('#mainPanle').height() + 26
        });
    } else {
        $('#tabs').tabs('select', subtitle);
    }
    tabClose();
}
function createFrame(url) {
    var s = '<iframe name="mainFrame" scrolling="no" frameborder="0"  src="' + url + '" style="width:100%;height:100%;" onLoad="iFrameHeight(this);"></iframe>';
    return s;
}
function iFrameHeight(ifm) {
    var fheight = 800;
    var cwin = ifm;
    if (cwin && document.getElementById) {
        try {
            if (cwin.contentDocument && cwin.contentDocument.body.offsetHeight) {
                fheight = cwin.contentDocument.body.offsetHeight; //FF NS
                cwin.height = fheight;
                $('#tabs').height(fheight).resize();
            }

            else if (cwin.Document && cwin.Document.body.scrollHeight) {
                fheight = cwin.Document.body.scrollHeight; //IE
                cwin.height = fheight;
                $('#tabs').height(fheight).resize();
            }
	                 
        } catch (e) {
            try {
                if (cwin.contentWindow.document && cwin.contentWindow.document.body.scrollHeight) {
                    fheight = cwin.contentWindow.document.body.scrollHeight;//Opera
                    cwin.height = fheight;
                    $('#tabs').height(fheight).resize();
                }
            }catch (e){}
        }
    }
	    

}

function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children("span").text();
        $('#tabs').tabs('close', subtitle);
    })

    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY,
        });

        var subtitle = $(this).children("span").text();
        $('#mm').data("currtab", subtitle);

        return false;
    });
}
//绑定右键菜单事件
function tabCloseEven() {
    //关闭当前
    $('#mm-tabclose').click(function () {
        var currtab_title = $('#mm').data("currtab");
        $('#tabs').tabs('close', currtab_title);
    })
    //全部关闭
    $('#mm-tabcloseall').click(function () {
        $('.tabs-inner span').each(function (i, n) {
            var t = $(n).text();
            $('#tabs').tabs('close', t);
        });
    });
    //关闭除当前之外的TAB
    $('#mm-tabcloseother').click(function () {
        var currtab_title = $('#mm').data("currtab");
        $('.tabs-inner span').each(function (i, n) {
            var t = $(n).text();
            if (t != currtab_title)
                $('#tabs').tabs('close', t);
        });
    });
    //关闭当前右侧的TAB
    $('#mm-tabcloseright').click(function () {
        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            //msgShow('系统提示','后边没有啦~~','error');
            alert('后边没有啦~~');
            return false;
        }
        nextall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            $('#tabs').tabs('close', t);
        });
        return false;
    });
    //关闭当前左侧的TAB
    $('#mm-tabcloseleft').click(function () {
        var prevall = $('.tabs-selected').prevAll();
        if (prevall.length == 0) {
            alert('到头了，前边没有啦~~');
            return false;
        }
        prevall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            $('#tabs').tabs('close', t);
        });
        return false;
    });

    //退出
    $("#mm-exit").click(function() {
        $('#mm').menu('hide');
    });
}