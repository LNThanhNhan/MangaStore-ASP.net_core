// showModal(title, description, yesBtnLabel = 'Yes', noBtnLabel = 'Cancel', callbackAfterClickingYesBtn);
// showModal(title, description, yesBtnLabel = 'Yes', noBtnLabel = 'Cancel', callbackAfterClickingYesBtn);
document.getElementById('btn1').onclick = () => showModal('Xác nhận xóa', 'Bạn có chắc là muốn xóa ?', 'Yes', 'Cancel', () => {
    //Do something after clicked yes button
    console.log('Xóa thành công!');
});