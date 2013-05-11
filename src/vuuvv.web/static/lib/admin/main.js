(function () {

function main() {
	var topbar = new Ext.toolbar.Toolbar ({
		region: 'north',
		border: false,
		split: true,
		height: 26,
		minSize: 26,
		maxSize: 26,
		items: [{
			xtype: 'button',
			text: '中宇官网管理平台',
			cls: 'x-btn-text-icon',
			icon: '/static/css/icons/house.png',
			disabled: true,
			disabledClass: ''
		}, "->", "-", {
			xtype: 'button',
			minWidth: 80,
			text: '刷新当前页',
			cls: 'x-btn-text-icon',
			icon: '/static/css/icons/arrow_refresh.png',
			handler: function(btn, e) {
				var tab = main_area.getActiveTab();
				tab.removeAll(true);
				tab.loader.load();
			}
		}, "-", {
			xtype: 'button',
			minWidth: 80,
			text: '全部关闭',
			cls: 'x-btn-text-icon',
			icon: '/static/css/icons/stop.png',
			handler: function(btn, e) {
				main_area.items.each(function(item) {
						if (item.closable) {
							main.area.remove(item, true);
						}
				});
			}
		}, "-", {
			xtype: 'button',
			minWidth: 80,
			text: '设置为常用页',
			cls: 'x-btn-text-icon',
			icon: '/static/css/icons/asterisk_yellow.png',
			handler: function(btn, e) {
			}
		}, "-", {
			xtype: 'button',
			minWidth: 80,
			text: '修改密码',
			cls: 'x-btn-text-icon',
			icon: '/static/css/icons/key.png',
			handler: function(btn, e) {
			}
		}, "-", {
			xtype: 'button',
			minWidth: 80,
			text: '帮助',
			cls: 'x-btn-text-icon',
			icon: '/static/css/icons/lightbulb.png',
			handler: function(btn, e) {
			}
		}, "-", {
			xtype: 'button',
			minWidth: 80,
			text: '注销',
			cls: 'x-btn-text-icon',
			icon: '/static/css/icons/lock_go.png',
			handler: function(btn, e) {
			}
		}, "-", {
			xtype: 'button',
			minWidth: 80,
			text: '退出',
			cls: 'x-btn-text-icon',
			icon: '/static/css/icons/door_out.png',
			handler: function(btn, e) {
			}
		}]
	});

	var menu = new Ext.tree.TreePanel({
		title: '功能菜单',
		region: 'west',
		autoScroll: true,
		enableTabScroll: true,
		collapsible: true,
		collapsed: false,
		iconCls: 'plugin',
		split: true,
		rootVisible: false,
		lines: false,
		width: 200,
		minSize: 220,
		maxSize: 220,
		root: {
			nodeType: 'async',
			id: '0',
			level: '0',
			expanded: true,
			text: '菜单',
			leaf: false
		}
	});

	var main_area = new Ext.TabPanel({
		id: "main_area",
		region: "center",
		autoScroll: true,
		enableTabScroll: true,
		activeTab: 0,
		onTitleDbClick: function(e, target, o) {
			var t = this.findTargets(e);
			var item = t.item;
			if (item && item.closable) {
				if (item.fireEvent('beforeclose', item) !== false) {
					item.fireEvent('close', item);
					this.remove(item);
				}
			}
		},
		items: [new Ext.Panel({
			id: 'tab-0001',
			title: '首页',
			autoScroll: true,
			layout: 'fit',
			border: false,
			iconCls: 'house',
			autoLoad: {
				url: '/manage/adminmain/main',
				scope: this,
				scripts: true,
				text: '页面加载中，请稍候...'
			}
		})]
	});

	new Ext.Viewport({
		//id: 'main_area_viewport',
		layout: 'border',
		items: [topbar,menu, main_area]
	});
}

Ext.onReady(function() {
	main();
});

} ());
