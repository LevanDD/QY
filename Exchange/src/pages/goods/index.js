import '../../assets/iconfont/iconfont.css';
import '../../commons/basic/comm.css';
import './goods.css';

import { fit } from '../../commons/basic/fit';
import { initData, initAction } from './goods';

$(function(e) {
    fit();
    initAction();
    initData();
});
