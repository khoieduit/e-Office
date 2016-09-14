function ckeditorFull(id){
	config={};
    config.language = 'vi';
    config.uiColor = '#42bdcc';
    config.colorButton_enableMore = true;
    config.toolbarCanCollapse = true;
    config.entities_latin = false;
    config.colorButton_backStyle = {
        element: 'span',
        styles: { 'background-color': '#(42bdcc)' }
    };
    config.toolbarGroups = [
            { name: 'document', groups: [ 'mode', 'document', 'doctools' ] },
            { name: 'clipboard', groups: [ 'clipboard', 'undo' ] },
            { name: 'editing', groups: [ 'find', 'selection', 'spellchecker', 'editing' ] },
            { name: 'forms', groups: [ 'forms' ] },
            '/',
            { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ] },
            { name: 'paragraph', groups: [ 'list', 'indent', 'blocks', 'align', 'bidi', 'paragraph' ] },
            { name: 'links', groups: [ 'links' ] },
            { name: 'insert', groups: [ 'insert' ] },
            '/',
            { name: 'styles', groups: [ 'styles' ] },
            { name: 'colors', groups: [ 'colors' ] },
            { name: 'tools', groups: [ 'tools' ] },
            { name: 'others', groups: [ 'others' ] },
            { name: 'about', groups: [ 'about' ] }
        ];
    config.removeButtons = 'Form,Radio,Checkbox,Textarea,Select,Button,ImageButton,HiddenField,Flash,TextField';
    CKEDITOR.replace( id,config);
}
function ckeditorStandar(id){
	config={};
    config.language = 'vi';
    config.uiColor = '#42bdcc';
    config.colorButton_enableMore = true;
    config.toolbarCanCollapse = true;
    config.colorButton_backStyle = {
        element: 'span',
        styles: { 'background-color': '#(42bdcc)' }
    };
    config.toolbarGroups = [
        { name: 'document', groups: [ 'mode', 'document', 'doctools' ] },
        { name: 'clipboard', groups: [ 'clipboard', 'undo' ] },
        { name: 'editing', groups: [ 'find', 'selection', 'spellchecker', 'editing' ] },
        { name: 'forms', groups: [ 'forms' ] },
        { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ] },
        { name: 'paragraph', groups: [ 'list', 'indent', 'blocks', 'align', 'bidi', 'paragraph' ] },
        { name: 'insert', groups: [ 'insert' ] },
        { name: 'colors', groups: [ 'colors' ] },
        { name: 'styles', groups: [ 'styles' ] },
        { name: 'tools', groups: [ 'tools' ] },
        '/',
        { name: 'links', groups: [ 'links' ] },
        '/',
        { name: 'others', groups: [ 'others' ] },
        { name: 'about', groups: [ 'about' ] }
    ];
    config.entities_latin = false;
    config.removeButtons = 'Save,NewPage,Preview,Print,Templates,PasteText,PasteFromWord,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,Image,Flash,Table,HorizontalRule,Iframe,PageBreak,Replace,Scayt,SelectAll,Unlink,Link,Language,Anchor,CreateDiv,ShowBlocks,About,BidiLtr,BidiRtl';
    CKEDITOR.replace( id,config);
}