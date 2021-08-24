﻿<%@ Page Language="C#" MasterPageFile="~/newMasterPage.master" AutoEventWireup="true"
    CodeFile="frmBingBusStopEntry.aspx.cs" Inherits="frmBingBusStopEntry" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .btnClose
        {
            color: #FFFFFF;
            background: url(images/btn_BG.png) repeat-x;
            height: 24px;
            padding: 0px 5px;
            font: 12px verdana;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript" src="http://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0"></script>

    <script type="text/javascript">
        // Initialize the map

        var map, dataLayer, infobox;
        var polyline = null;
        var polylineMask = null;
        var MM = Microsoft.Maps;
        function showmap() {
            map = new Microsoft.Maps.Map(document.getElementById("mapDiv"),
                {
                    credentials: 'AqIe3_GT5VGRNfJWG2VfWfkuRNoxSNvONjRENcAbHns_l2N3rdKKk7vWJ71nZqKs',
                    center: new Microsoft.Maps.Location(19.111239929515, 73.040088621345),
                    mapTypeId: Microsoft.Maps.MapTypeId.road,
                    zoom: 15
                });
            // Retrieve the location of the map center
            var center = map.getCenter();


            // Add a pin to the center of the map
            var pin = new Microsoft.Maps.Pushpin(center, { text: '1', draggable: true });
            map.entities.push(pin);
            LoadMap();

            //Wire events for dragging
            Microsoft.Maps.Events.addHandler(pin, 'dragstart', StartDragHandler);
            Microsoft.Maps.Events.addHandler(pin, 'drag', DragHandler);
            Microsoft.Maps.Events.addHandler(pin, 'dragend', EndDragHandler);

        }


        function StartDragHandler(e) {
            //document.getElementById("mode").innerHTML = "Dragging started (dragstart event)."
            document.getElementById("slider").style.display = "display";
        }

        function DragHandler(e) {
            //document.getElementById("mode").innerHTML = "Dragging in process (drag event).."
            var location = (e.toString());
            alert(location);
            
            var a = location.split(' ');// Delimiter is a string
            for (var i = 0; i < a.length; i++) {
                alert(a[i])
            }
            var loc = e.entity.getLocation();
            //document.getElementById("MouseLat").innerHTML = loc.latitude.toFixed(4);
            //document.getElementById("MouseLng").innerHTML = loc.longitude.toFixed(4);
            
            document.getElementById("<%= latbox.ClientID %>").value = loc.latitude.toFixed(12);
            document.getElementById("<%= lonbox.ClientID %>").value = loc.longitude.toFixed(12);
        }

        function EndDragHandler(e) {
            //document.getElementById("mode").innerHTML = "Dragging stopped (dragend event)."
            //document.getElementById("slider").style.display = "none";
        }

        $(document).ready(function() {
            $(".triggerBSE").click(function() {
                $(".panel8").toggle("fast");
                $(this).toggleClass("activeNew");
                return false;
            });
        });
        function closepan() {
            document.getElementById("slider").style.display = "none";
        }





        function LoadMap() {

            //        map = new Microsoft.Maps.Map(document.getElementById("mapDiv"),
            //                {
            //                    credentials: 'AkJzJ92quLAPmLYVjUuZfFkOmynnTM60QaMyVNcUuHRu3cI74u2Q7NOuEKI5viNB',
            //                    center: new Microsoft.Maps.Location(19.104630138906, 73.029488531318),
            //                    mapTypeId: Microsoft.Maps.MapTypeId.road,
            //                    zoom: 12
            //                });
            dataLayer = new Microsoft.Maps.EntityCollection();
            map.entities.push(dataLayer);
            var infoboxLayer = new Microsoft.Maps.EntityCollection();
            map.entities.push(infoboxLayer);
            infobox = new Microsoft.Maps.Infobox(new Microsoft.Maps.Location(0, 0), { visible: false, offset: new Microsoft.Maps.Point(0, 20) });
            infoboxLayer.push(infobox);

            ///Adding BusStop
            var busarrlength;
            var buslatlngsplit = new Array();
            var buslatlngsplit1 = new Array();

            var stop_data = document.getElementById("<%= hdnStops.ClientID%>").value;
            //        alert(stop_data);

            if (stop_data != null && stop_data != '') {
                buslatlngsplit = stop_data.split('#&');
                //arrlength = buslatlngsplit.length - 1;
                var buslatlng = new Array();
                var busll;
                var pushpinOptions1 = { icon: 'images/Bus_Stop_ Sign.png' };

                for (var p = 0; p < buslatlngsplit.length - 1; p++) {
                    if (buslatlngsplit[p] != null) {
                        var latlngtemp = buslatlngsplit[p].split("#");

                        //busll = new VELatLong(latlngtemp[0], latlngtemp[1]);

                        busll = new Microsoft.Maps.Location(latlngtemp[0], latlngtemp[1]);
                        var busstopaddress = latlngtemp[2];
                        /////


                        var busstoppin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(latlngtemp[0], latlngtemp[1]), pushpinOptions1);
                        busstoppin.Title = "Bus Stop";
                        busstoppin.Description = busstopaddress;
                        Microsoft.Maps.Events.addHandler(busstoppin, 'mouseover', displayInfobox);
                        dataLayer.push(busstoppin);
                    } //end if
                } // end for


            }

        }

        function displayInfobox(e) {
            if (e.targetType == 'pushpin') {
                infobox.setLocation(e.target.getLocation());
                infobox.setOptions({ visible: true, title: e.target.Title, description: e.target.Description });
            }
        }


        



    </script>

    <script type="text/javascript">
   
    
    </script>

    <div>
 
        <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="hdnCentermap" runat="server" />
        <table style="width: 962px">
            <tr align="left">
                <td style="width: 100%">
                    <div id='mapDiv' style="position: relative; width: 922px; margin: 0 auto; height: 450px;">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="panel8" id="slider">
        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" Width="300px">
                    <table width="100%" align="center">
                        <tr>
                            <td colspan="2" style="height: 21px">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/delete.png"
                                    OnClientClick="javascript:return closepan11();" ToolTip="Close" Visible="False" />
                            </td>
                        </tr>
                        <tr height="35">
                            <td style="width: 35%; height: 21px; color: #41413f;" align="left">
                                <asp:Label ID="Label53" Visible="false" runat="server" Font-Bold="True" Font-Names="Verdana"
                                    Font-Size="8pt" Text="Route Name"></asp:Label>
                            </td>
                            <td style="width: 65%; height: 21px" align="left">
                            </td>
                        </tr>
                        <tr height="35">
                            <td align="left" style="color: #41413f;">
                                <asp:Label ID="Label51" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                                    Text="Enter Name"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtName" runat="server" MaxLength="20" Width="160px" Height="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="35">
                            <td align="left" style="color: #41413f;">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                                    Text="Latitude"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="latbox" runat="server" Width="160px" Height="20" MaxLength="6" AutoPostBack="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr height="35">
                            <td align="left" style="color: #41413f;">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                                    Text="Longitude"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="lonbox" runat="server" Width="160px" Height="20" AutoPostBack="True"></asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr height="85">
                        <td align="left" style="color:#41413f;">
                            <asp:Label ID="Label52" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                                Text="Address"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBox8" runat="server" MaxLength="25" TextMode="MultiLine" ToolTip="Please Enter Location Name"
                                Width="160px" Height="70px"></asp:TextBox>
                        </td>
                    </tr>--%>
                        <tr height="35">
                            <td align="left">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn" ValidationGroup="route" 
                                    Text="Add Location" />
                                <%--<asp:Button ID="Button1" runat="server" CssClass="btnClose" 
                            Text="Close" OnClientClick="closepan();" />--%>
                            </td>
                        </tr>
                    </table>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" />
                    <asp:HiddenField ID="hdnStops" runat="server" />
                </asp:Panel>
                <div id="mode">
                </div>
                <div id="MouseLat">
                </div>
                <div id="MouseLng">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="panel8Close">
            <a href="javascript:void(0)" onclick="closepan();">
                <img src="images/Close.png" width="24" height="24" border="0" /></a>
        </div>
    </div>
    <a class="triggerBSE" href="#">Set Bus Stop</a>
</asp:Content>
