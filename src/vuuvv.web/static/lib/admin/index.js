var btn = new Ext.Button({
	text : '我是一个Ext按钮',
	handler : function() {
			Ext.MessageBox.alert('提示框', '代码如尿崩，谁与我争疯！');
	}
});
var panel = new Ext.Panel({
	title : '一个panel',
	items : [btn]
});

var tab = Ext.getCmp("main_area").getActiveTab();
tab.add(panel);
tab.doLayout();
