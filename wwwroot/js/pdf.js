// window.generateUserPDF = function (userData) {
//     const { jsPDF } = window.jspdf;
//     const doc = new jsPDF();

//     // Load Thai font from a file in wwwroot/fonts/
//     fetch('/fonts/THSarabunNew.ttf')
//         .then(response => response.arrayBuffer())
//         .then(fontData => {
//             // Convert the font data into base64 format
//             const base64Font = arrayBufferToBase64(fontData);

//             // Add font to jsPDF virtual file system
//             doc.addFileToVFS('THSarabunNew.ttf', base64Font);

//             // Register the font
//             doc.addFont('THSarabunNew.ttf', 'THSarabunNew', 'normal');

//             // Set the font
//             doc.setFont('THSarabunNew');
//             doc.setFontSize(16);
//             doc.text("รายชื่อคนไข้", 10, 10);

//             doc.setFontSize(12);
//             let y = 20;

//             // Table Headers
//             doc.text("ID       Name           Role       CID", 10, y);
//             doc.line(10, y + 1, 200, y + 1); // Draw a line under header
//             y += 10;

//             // Loop through user data
//             userData.forEach((user) => {
//                 doc.text(`${user.id}   ${user.loginName}   ${user.role}   ${user.cid}`, 10, y);
//                 y += 10;
//             });

//             // Save the PDF
//             doc.save("UserList.pdf");
//         })
//         .catch(error => console.error("Error loading font:", error));
// };

// // Helper function to convert ArrayBuffer to Base64
// function arrayBufferToBase64(buffer) {
//     let binary = '';
//     let bytes = new Uint8Array(buffer);
//     let len = bytes.byteLength;
//     for (let i = 0; i < len; i++) {
//         binary += String.fromCharCode(bytes[i]);
//     }
//     return btoa(binary);
// }

window.generateUserPDF = function (userData) {
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    // Load both Regular and Bold Thai fonts
    Promise.all([
        fetch('/fonts/THSarabunNew.ttf').then(response => response.arrayBuffer()),
        fetch('/fonts/THSarabunNew-Bold.ttf').then(response => response.arrayBuffer())
    ]).then(([regularFont, boldFont]) => {
        // Convert fonts to Base64
        const base64Regular = arrayBufferToBase64(regularFont);
        const base64Bold = arrayBufferToBase64(boldFont);

        // Add fonts to jsPDF virtual file system
        doc.addFileToVFS('THSarabunNew.ttf', base64Regular);
        doc.addFont('THSarabunNew.ttf', 'THSarabunNew', 'normal');

        doc.addFileToVFS('THSarabunNew-Bold.ttf', base64Bold);
        doc.addFont('THSarabunNew-Bold.ttf', 'THSarabunNew', 'bold');

        // Set Font to Bold for Title
        doc.setFont('THSarabunNew', 'bold');
        doc.setFontSize(18);
        doc.text("รายชื่อคนไข้", 10, 10);

        doc.setFontSize(14);
        let y = 20;

        // Set Bold Font for Table Headers
        doc.setFont('THSarabunNew', 'normal');
        doc.text("ID       Name           Role       CID", 10, y);
        doc.line(10, y + 2, 200, y + 2); // Underline Header
        y += 10;

        // Set Regular Font for Data
        doc.setFont('THSarabunNew', 'normal');
        doc.setFontSize(12);

        // userData.forEach((user) => {
        //     doc.text(`${user.id}   ${user.loginName}   ${user.role}   ${user.cid}`, 10, y);
        //     y += 10;
        // });

        // Define Table Headers
        const headers = [["ID", "Name", "Role", "CID"]];

        // Convert user data into table format
        const data = userData.map(user => [
            user.id,
            user.loginName,
            user.role,
            user.cid
        ]);

        // Use autoTable plugin for table formatting
        doc.autoTable({
            head: headers,
            body: data,
            startY: 25, // Start table below title
            styles: {
                font: "THSarabunNew",
                fontSize: 14,
            },
            headStyles: {
                fillColor: [41, 128, 185], // Blue header background
                textColor: 255, // White text color
                fontStyle: 'bold',
            },
            alternateRowStyles: {
                fillColor: [240, 240, 240], // Light gray for alternating rows
            },
            margin: { left: 14, right: 14 },
        });

        // Save the PDF
        doc.save("UserList.pdf");
    }).catch(error => console.error("Error loading fonts:", error));
};


// Helper function to convert ArrayBuffer to Base64
function arrayBufferToBase64(buffer) {
    let binary = '';
    let bytes = new Uint8Array(buffer);
    let len = bytes.byteLength;
    for (let i = 0; i < len; i++) {
        binary += String.fromCharCode(bytes[i]);
    }
    return btoa(binary);
}




