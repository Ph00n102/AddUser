window.generatePDF = function (orderDetails, orderContinueReview, progressNoteDetails, hn, an) {
    if (!window.jspdf) {
        console.error("jsPDF is not loaded!");
        return;
    }

    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    // Generate Barcode for HN
    const canvas = document.createElement("canvas");
    JsBarcode(canvas, hn, {
        format: "CODE128",
        displayValue: true,
        width: 2,
        height: 40
    });

   const barcodeDataURL = canvas.toDataURL("image/png");

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
        doc.text(`รายการ Order คนไข้ HN: ${hn} AN: ${an}`, 10, 10);

        // Add barcode to PDF
        doc.addImage(barcodeDataURL, "PNG", 150, 10, 50, 20);

        let y = 20;

        // Table Headers
        const headers = [["Order Date", "Order Oneday", "Order Continuous", "Progress Note"]];
        const bodyData = [];

        // Loop through orders and build table rows
        orderDetails.forEach((order) => {
            let onedayOrders = "";
            let continuousOrders = "";
            let progressNotes = "";

            // Oneday orders
            if (order.oneday && order.oneday.length > 0) {
                order.oneday.forEach(drug => {
                    onedayOrders += `• ${drug.drugName} ${drug.orderItemDetail} `;
                    if (drug.offOrderItemId) {
                        onedayOrders += `(off: ${drug.offOrderDrugName} ${drug.offOrderItemDetail}) `;
                    }
                    onedayOrders += `\n${drug.doctorRole} ${drug.doctorName}\n ${drug.orderDate} ${drug.orderTime}\n\n`;
                });
            } else {
                onedayOrders = "ไม่มีคำสั่งใช้ยาแบบ Oneday";
            }

            // Continuous orders
            if (order.continuous && order.continuous.length > 0) {
                order.continuous.forEach(drug => {
                    continuousOrders += `• ${drug.drugName} ${drug.orderItemDetail} `;
                    if (drug.offOrderItemId) {
                        continuousOrders += `(off: ${drug.offOrderDrugName} ${drug.offOrderItemDetail}) `;
                    }
                    continuousOrders += `\n${drug.doctorRole} ${drug.doctorName}\n ${drug.orderDate} ${drug.orderTime}\n\n`;
                });
            } else {
                continuousOrders = "ไม่มีคำสั่งใช้ยาแบบ Continuous";
            }

            // Append orderContinueReview after continuous orders
            if (orderContinueReview && orderContinueReview.length > 0) {
                continuousOrders += "\nReview of Treatment\n";
                orderContinueReview.forEach(review => {
                    continuousOrders += `- ${review.drugName} ${review.orderItemDetail}\n`;
                });
            }

            // Progress Notes
            let progressNoteMatch = progressNoteDetails.find(p => p.progressNoteDate === order.orderDate);
            if (progressNoteMatch) {
                progressNoteMatch.createUser.forEach(user => {
                    user.progressNoteList.forEach(detail => {
                        progressNotes += ` ${detail.progressNoteItemType}\n${detail.progressNoteItemDetail}\n${detail.progressNoteItemDetail2}\n ${detail.progressNoteDate}  ${detail.progressNoteTime} น.\n👤 ${user.createUserName}\n\n`;
                    });
                });
            } else {
                progressNotes = "ไม่มี Progress Note";
            }

            bodyData.push([
                order.orderDate,
                onedayOrders,
                continuousOrders,
                progressNotes
            ]);
        });

        // Use autoTable plugin for formatting the table
        doc.autoTable({
            head: headers,
            body: bodyData,
            startY: y + 10,
            styles: {
                font: "THSarabunNew",
                fontSize: 12,
            },
            headStyles: {
                fillColor: [41, 128, 185], // Blue header background
                textColor: 255, // White text color
                fontStyle: 'bold',
            },
            alternateRowStyles: {
                fillColor: [240, 240, 240], // Light gray for alternating rows
            },
            columnStyles: {
                0: { cellWidth: 30 }, // Order Date
                1: { cellWidth: 50 }, // Order Oneday
                2: { cellWidth: 50 }, // Order Continuous
                3: { cellWidth: 50 }  // Progress Note
            },
            margin: { left: 10, right: 10 },
        });

        // Save the PDF
        doc.save(`OrderList_HN:${hn} AN:${an}.pdf`);
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