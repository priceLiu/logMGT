<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogList.aspx.cs" Inherits="log4netUTS.Web.LogList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>日志列表</title>
    <link href="/Styles/jquery.pager.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        table,tr,td{ border:none;}
        ul,li{ list-style:none;}
        /*=========分页=========== */
        .boxmain{width:1100px; margin:0 auto;}
        .myPager
        {
            text-align: center;
            text-align: right;
            width: 1100px;
            height: 34px;
        }
        .myPager .pages
        {
            float:right;
            margin: 3px 6px 0 0;
        }
         .myPager .pages li{float:left; line-height: 25px;    padding: 0 5px;}
        .Pac_conbox
        {
            width: 1100px;
        }
        
        .Pac_conbox #listHeader, .Pac_conbox #logListBody
        {
            list-style-type: none;
            width: 1100px;
        }
        
        .Pac_conbox h2{ font:bold 14px/30px "宋体";}
        #listHeader tr{height:auto;}
        #listHeader td{ border: 1px solid green; text-align:center; word-wrap: break-word; line-height: 25px;}
        #listHeader .width80
        {
            width: 100px;
            padding:0 5px;
        }
         #listHeader .width120
        {
            width: 140px;
            padding:0 5px;
        }
        #listHeader .error{width:300px; text-align:left;padding:0 5px; }
    </style>
    <script src="/Scripts/jquery.1.7.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="boxmain">
        <div class="Pac_conbox">
            <h2 style="text-align:left; font-weight:bold; font-size:16px">
                日志列表</h2>
                <table id="listHeader" width="100%">
                    <tr  style="background-color:#B1DBA6">
                        <td class="width80">应用程序</td>
                        <td class="width80">IP</td>
                        <td class="width80">事件类型</td>
                        <td class="error">错误信息</td>
                        <td class="width120">错误时间</td>
                        <td class="width80">错误类型</td>
                        <td class="width120">创建时间</td>
                    </tr>
                
                <tbody  id="logListBody">
              
                </tbody>
            
            </table>
        </div>
        <div id="myPager" class="myPager">
        </div>
    </div>
    </form>
</body>
</html>
<script src="/Scripts/artDialog415/artDialog.js?skin=aero" type="text/javascript"></script>
<script src="/Scripts/jquery.pager.js?83232" type="text/javascript"></script>
<script type="text/javascript" language="javascript">

   //每页记录数
    var pageSize = 5;

    $(function () {
        //绑定数据
        QueryData(1, pageSize);
    });

    function changepage(pageIndex) {
        //重新加载数据
        QueryData(pageIndex, pageSize);
    }

    function showMessage(title, content) {
        art.dialog({ title: title, content: content, ok: true, lock: true, fixed: false });
    }

    //查询数据
    function QueryData(pageIndex, pageSize) {
        var date = new Date();
        var temp = date.getMinutes().toString() + date.getSeconds().toString() + date.getMilliseconds().toString();
        $.ajax({
            type: "POST",
            async: false,
            url: "/Handler/GetLogData.ashx?temp=" + temp,
            data: { pageIndex: pageIndex - 1, pageSize: pageSize },
            dataType: "json",
            error: function (doc, result, message) {
                showMessage("错误", message || result);
            },
            success: function (response) {
                if (response.Result) {
                    BindData(response.Data);
                    var rowCount = response.Count;
                    if (rowCount > 0) {
                        var pageCount = Math.ceil(rowCount / pageSize);
                        BindPageBar(pageIndex, pageCount);
                    }
                }
                else {
                    showMessage("提示", response.Message);
                }
            }
        });
    }

    function BindData(data) {
        var html = [];

        if (data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                var row = data[i];
                html.push("<tr>");
                html.push("<td class=\"width80\">" + row.AppName + "</td>");
                html.push("<td class=\"width80\">" + row.ServerTag + "</td>");
                html.push("<td class=\"width80\">" + row.EventType + "</td>");
                html.push("<td class=\"error\">" + row.Message + "</td>");
                html.push("<td class=\"width120\">" + getDate(row.ErrorTime) + "</td>");
                html.push("<td class=\"width80\">" + row.ErrorType + "</td>");
                html.push("<td class=\"width120\">" + getDate(row.CreatedTime) + "</td>");
                html.push("</tr>");
            }
        }

        $("#logListBody").html(html.join(""));
    }

    function BindPageBar(pageIndex, pageCount) {
        $("#myPager").pager({ pagenumber: pageIndex, pagecount: pageCount, buttonClickCallback: changepage });
    }

    function getDate(source) {
        var date = eval('new ' + eval(source).source);
        var d = new Date();
        d.getf
        return date.getFullYear() + "-" + pad((date.getMonth() + 1), 2, "0") + "-" + pad(date.getDate(), 2, "0") + "&nbsp;" + pad(date.getHours(), 2, "0") + ":" + pad(date.getMinutes(), 2, "0") + ":" + pad(date.getSeconds(), 2, "0");
    }

    function pad(source, len, fix) {
        var sourceLen = source.toString().length;
        var pre = "";

        if (sourceLen < len) {
            var subLen = len - sourceLen;
            for (var i = 0; i < subLen; i++) {
                pre += fix;
            }
        }

        return pre + source;
    }
</script>
