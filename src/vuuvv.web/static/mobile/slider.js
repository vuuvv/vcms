define("/mw/base/styles/component/slider/js/slider.js",["zepto","../../../../utils/smallCss3/css3"],function(a,b,c){
	var d=a("zepto"),e=a("../../../../utils/smallCss3/css3"),f=/android/gi.test(navigator.appVersion),g=e.has3d(),h=e.hasTransform(),i=g?"translate3d(":"translate(",j=g?",0)":")";
	return d.touchSlider=function(a,b){
		if(!a)return null;
		b?b.container=a:b=typeof a=="string"?{
			container:a
		}
		:a,d.extend(this,{
			container:".slider",wrap:null,panel:null,trigger:null,activeTriggerCls:"sel",hasTrigger:!1,steps:0,left:0,visible:1,margin:0,curIndex:0,duration:300,loop:!1,play:!1,interval:5e3,useTransform:!f,lazy:".lazyimg",lazyIndex:1,callback:null,prev:null,next:null,activePnCls:"none"
		}
		,b),this.findEl()&&this.init()&&this.increaseEvent()
	}
	,d.extend(d.touchSlider.prototype,{
		reset:function(a){
			d.extend(this,a||{}),this.init()
		}
		,findEl:function(){
			var a=this.container=d(this.container);
			return a.length?(this.wrap=this.wrap&&a.find(this.wrap)||a.children().first(),this.wrap.length?(this.panel=this.panel&&a.find(this.panel)||this.wrap.children().first(),this.panel.length?(this.panels=this.panel.children(),this.panels.length?(this.trigger=this.trigger&&a.find(this.trigger),this.prev=this.prev&&a.find(this.prev),this.next=this.next&&a.find(this.next),this):(this.container.hide(),null)):null):null):null
		}
		,init:function(){
			var a=this.wrap,b=this.panel,c=this.panels,d=this.trigger,e=this.len=c.length,f=this.margin,g=0,k=this.visible,l=this.useTransform=h?this.useTransform:!1;
			this.steps=this.steps||a.width(),c.each(function(a,b){
				g+=b.offsetWidth
			}),f&&typeof f=="number"&&(g+=(e-1)*f,this.steps+=f),k>1&&(this.loop=!1);
			var m=this.left;
			m-=this.curIndex*this.steps,this.setCoord(b,m),l&&(a.css({
				"-webkit-transform":"translate3d(0,0,0)"
			}),b.css({
				"-webkit-backface-visibility":"hidden"
			}),c.css({
				"-webkit-transform":i+"0,0"+j
			}));
			var n=this._pages=Math.ceil(e/k);
			this._minpage=0,this._maxpage=this._pages-1,this.loadImg(),this.updateArrow();
			if(n<=1)return d&&d.hide(),null;
			if(this.loop){
				b.append(c[0].cloneNode(!0));
				var o=c[e-1].cloneNode(!0);
				b.append(o),this.getImg(o),o.style.cssText+="position:relative;left:"+ -this.steps*(e+2)+"px;",g+=c[0].offsetWidth,g+=c[e-1].offsetWidth
			}
			b.css("width",g);
			if(d&&d.length){
				var p="",q=d.children();
				if(!q.length){
					for(var r=0;r<n;r++)p+="<span"+(r==this.curIndex?" class="+this.activeTriggerCls+"":"")+"></span>";
					d.html(p)
				}
				this.triggers=d.children(),this.triggerSel=this.triggers[this.curIndex]
			}
			else this.hasTrigger=!1;
			return this
		}
		,increaseEvent:function(){
			var a=this,b=a.wrap[0],c=a.prev,e=a.next,f=a.triggers;
			b.addEventListener&&(b.addEventListener("touchstart",a,!1),b.addEventListener("touchmove",a,!1),b.addEventListener("touchend",a,!1),b.addEventListener("webkitTransitionEnd",a,!1),b.addEventListener("msTransitionEnd",a,!1),b.addEventListener("oTransitionEnd",a,!1),b.addEventListener("transitionend",a,!1)),a.play&&a.begin(),c&&c.length&&c.on("click",function(b){
				a.backward.call(a,b)
			}),e&&e.length&&e.on("click",function(b){
				a.forward.call(a,b)
			}),a.hasTrigger&&f&&f.each(function(b,c){
				d(c).on("click",function(){
					a.slideTo(b)
				})
			})
		}
		,handleEvent:function(a){
			switch(a.type){
				case"touchstart":this.start(a);
				break;
				case"touchmove":this.move(a);
				break;
				case"touchend":case"touchcancel":this.end(a);
				break;
				case"webkitTransitionEnd":case"msTransitionEnd":case"oTransitionEnd":case"transitionend":this.transitionEnd(a)
			}
		}
		,loadImg:function(a){
			a=a||0,a<this._minpage?a=this._maxpage:a>this._maxpage&&(a=this._minpage);
			var b=this.visible,c=this.lazyIndex-1,d=c+a;
			if(d>this._maxpage)return;
			d+=1;
			var e=(a&&c+a||a)*b,f=d*b,g=this.panels;
			f=Math.min(g.length,f);
			for(var h=e;h<f;h++)this.getImg(g[h])
		}
		,getImg:function(a){
			if(!a)return;
			a=d(a);
			if(a.attr("l"))return;
			var b=this,c=b.lazy,e="img"+c;
			c=c.replace(/^\.|#/g,""),a.find(e).each(function(a,b){
				var e=d(b);
				src=e.attr("dataimg"),src&&e.attr("src",src).removeAttr("dataimg").removeClass(c)
			}),a.attr("l","1")
		}
		,start:function(a){
			var b=a.touches[0];
			this._movestart=undefined,this._disX=0,this._coord={
				x:b.pageX,y:b.pageY
			}
		}
		,move:function(a){
			if(a.touches.length>1||a.scale&&a.scale!==1)return;
			var b=a.touches[0],c=this._disX=b.pageX-this._coord.x,d=this.left,e;
			typeof this._movestart=="undefined"&&(this._movestart=!!(this._movestart||Math.abs(c)<Math.abs(b.pageY-this._coord.y))),this._movestart||(a.preventDefault(),this.stop(),this.loop||(c/=!this.curIndex&&c>0||this.curIndex==this._maxpage&&c<0?Math.abs(c)/this.steps+1:1),e=d-this.curIndex*this.steps+c,this.setCoord(this.panel,e),this._disX=c)
		}
		,end:function(a){
			if(!this._movestart){
				var b=this._disX;
				b<-10?(a.preventDefault(),this.forward()):b>10&&(a.preventDefault(),this.backward()),b=null
			}
		}
		,backward:function(a){
			a&&a.preventDefault&&a.preventDefault();
			var b=this.curIndex,c=this._minpage;
			b-=1,b<c&&(this.loop?b=c-1:b=c),this.slideTo(b),this.callback&&this.callback(Math.max(b,c),-1)
		}
		,forward:function(a){
			a&&a.preventDefault&&a.preventDefault();
			var b=this.curIndex,c=this._maxpage;
			b+=1,b>c&&(this.loop?b=c+1:b=c),this.slideTo(b),this.callback&&this.callback(Math.min(b,c),1)
		}
		,setCoord:function(a,b){
			this.useTransform&&a.css("-webkit-transform",i+b+"px,0"+j)||a.css("left",b)
		}
		,slideTo:function(a,b){
			a=a||0,this.curIndex=a;
			var c=this.panel,d=c[0].style,e=this.left-a*this.steps;
			d.webkitTransitionDuration=d.MozTransitionDuration=d.msTransitionDuration=d.OTransitionDuration=d.transitionDuration=(b||this.duration)+"ms",this.setCoord(c,e),this.loadImg(a)
		}
		,transitionEnd:function(){
			var a=this.panel,b=a[0].style,c=this.loop,d=this.curIndex;
			c&&(d>this._maxpage?this.curIndex=0:d<this._minpage&&(this.curIndex=this._maxpage),this.setCoord(a,this.left-this.curIndex*this.steps)),!c&&d==this._maxpage?(this.stop(),this.play=!1):this.begin(),this.update(),this.updateArrow(),b.webkitTransitionDuration=b.MozTransitionDuration=b.msTransitionDuration=b.OTransitionDuration=b.transitionDuration=0
		}
		,update:function(){
			var a=this.triggers,b=this.activeTriggerCls,c=this.curIndex;
			a&&a[c]&&(this.triggerSel&&(this.triggerSel.className=""),a[c].className=b,this.triggerSel=a[c])
		}
		,updateArrow:function(){
			var a=this.prev,b=this.next;
			if(!a||!a.length||!b||!b.length)return;
			if(this.loop)return;
			var c=this.curIndex,d=this.activePnCls;
			c<=0&&a.addClass(d)||a.removeClass(d),c>=this._maxpage&&b.addClass(d)||b.removeClass(d)
		}
		,begin:function(){
			var a=this;
			a.play&&!a._playTimer&&(a.stop(),a._playTimer=setInterval(function(){
				a.forward()
			}
			,a.interval))
		}
		,stop:function(){
			var a=this;
			a.play&&a._playTimer&&(clearInterval(a._playTimer),a._playTimer=null)
		}
		,destroy:function(){
			var a=this,b=a.wrap[0],c=a.prev,e=a.next,f=a.triggers;
			b.removeEventListener&&(b.removeEventListener("touchstart",a,!1),b.removeEventListener("touchmove",a,!1),b.removeEventListener("touchend",a,!1),b.removeEventListener("webkitTransitionEnd",a,!1),b.removeEventListener("msTransitionEnd",a,!1),b.removeEventListener("oTransitionEnd",a,!1),b.removeEventListener("transitionend",a,!1)),c&&c.length&&c.off("click"),e&&e.length&&e.off("click"),a.hasTrigger&&f&&f.each(function(a,b){
				d(b).off("click")
			})
		}
	}),d.touchSlider.cache=[],d.fn.slider=function(a){
		return this.each(function(b,c){
			c.getAttribute("l")||(c.setAttribute("l",!0),d.touchSlider.cache.push(new d.touchSlider(c,a)))
		})
	}
	,d.touchSlider.destroy=function(){
		var a=d.touchSlider.cache,b=a.length;
		if(b<1)return;
		for(var c=0;c<b;c++)a[c].destroy();
		d.touchSlider.cache=[]
	}
	,d.touchSlider
});

