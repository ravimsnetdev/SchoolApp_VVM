<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolAppUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <script>
     document.addEventListener("DOMContentLoaded", function () {
         var ctx = document.getElementById('attendanceChart').getContext('2d');
         new Chart(ctx, {
             type: 'line',
             data: {
                 labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                 datasets: [{
                     label: 'Present Students',
                     data: [1120, 1105, 1110, 1095, 1100, 1080],
                     borderColor: 'rgba(54, 162, 235, 1)',
                     backgroundColor: 'rgba(54, 162, 235, 0.2)',
                     fill: true,
                     tension: 0.3
                 }]
             },
             options: {
                 responsive: true,
                 plugins: {
                     legend: { display: true, position: 'bottom' }
                 }
             }
         });
     });
     </script>

    <h3 class="text-primary mb-4">🏫 School Dashboard</h3>

    <!-- Top Stats -->
    <div class="row g-3 mb-4">
        <div class="col-md-3">
            <div class="card text-white bg-primary shadow">
                <div class="card-body text-center">
                    <h6>Total Students</h6>
                    <h2><asp:Label ID="lblStudentsCount" runat="server" /></h2>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-white bg-success shadow">
                <div class="card-body text-center">
                    <h6>Total Teachers</h6>
                    <h2><asp:Label ID="lblTeachersCount" runat="server" /></h2>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-white bg-info shadow">
                <div class="card-body text-center">
                    <h6>Present Students</h6>
                    <h2><asp:Label ID="lblPresentStudents" runat="server" /></h2>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-white bg-danger shadow">
                <div class="card-body text-center">
                    <h6>Absent Students</h6>
                    <h2><asp:Label ID="lblAbsentStudents" runat="server" /></h2>
                </div>
            </div>
        </div>
    </div>

    <!-- Attendance Chart & Notices -->
    <div class="row g-3">
        <div class="col-md-8">
            <div class="card shadow">
                <div class="card-header bg-light">
                    <strong>📊 Attendance Trend</strong>
                </div>
                <div class="card-body">
                    <!-- Placeholder for chart -->
                    <canvas id="attendanceChart"></canvas>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card shadow">
                <div class="card-header bg-light">
                    <strong>📢 Notices</strong>
                </div>
                <div class="card-body">
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">School Annual Day on 25th Jan</li>
                        <li class="list-group-item">Fee due date: 10th Feb</li>
                        <li class="list-group-item">Republic Day Holiday 🎉</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

