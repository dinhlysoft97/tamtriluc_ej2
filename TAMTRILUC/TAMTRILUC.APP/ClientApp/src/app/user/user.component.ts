import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users: any = {
    data:[],
    pageSize:5,
    pageNumber:0,
    totalRecord:0,
    totalPages: 0,
  }

  user:any = {
    userID:'',
    userName:'',
    gender:'',
    age: 0,
    address:'',
    phone:'',
  }

  isEdit: boolean = true;

  constructor(
    private http: HttpClient,
     @Inject('BASE_URL') baseUrl: string) {
  }

  ngOnInit() {
    this.searchUser(1);
  }

  searchUser(cPage){
    let data1 = {
      key :'',
      pageNumber: cPage,
      pageSize:5,
    }

   this.http.post('https://localhost:44309/' + 'api/User/search-user', data1).subscribe(result => {
      this.users = result;
      this.users = this.users.data;
    }, error => console.error(error));
  }

  searchNext(){
    if(this.users.pageNumber < this.users.totalPages){
      let nextPage = this.users.pageNumber + 1;
      let data0 = {
        pageNumber: nextPage,
        pageSize:5,
        key:'',
      }
      this.http.post('https://localhost:44309/' + 'api/User/search-user', data0).subscribe(result => {
        this.users = result;
        this.users = this.users.data;
      }, error => console.error(error));
    }else{
      alert("Bạn đang ở trang cuối cùng");
    }
  }

  searchPrevious(){
    if(this.users.pageNumber > 1){
      let nextPage = this.users.pageNumber - 1;
      let data1 = {
        pageNumber: nextPage,
        pageSize:5,
        key:'',
      }
      this.http.post('https://localhost:44309/' + 'api/User/search-user', data1).subscribe(result => {
        this.users = result;
        this.users = this.users.data;
      }, error => console.error(error));
    }else{
      alert("Bạn đang ở trang đầu tiên");
    }
  }

  openModel(isNew, index){
    if(isNew){
      this.isEdit = false;
      this.user = {
        userID:'',
        userName:'',
        gender:'',
        age: 0,
        address:'',
        phone:'',
      }
    }else{
      this.isEdit = true;
      this.user = index;
    }
    $('#exampleModal').modal('show');
  }

  deleteUser(index){
    var data2 = index;
    this.http.post('https://localhost:44309/' + 'api/User/delete-user', data2).subscribe(result => {
      var res:any = result;
      if(res.success){
        this.user = res.data;
        this.searchUser(1);
        alert('Xóa thông tin học viên thành công!');
      }
    }, error => console.error(error));
  }

  insertUser(){
    var data3 = this.user;
    this.http.post('https://localhost:44309/' + 'api/User/insert-user', data3).subscribe(result => {
      var res:any = result;
      if(res.success){
        this.user = res.data;
        this.searchUser(1);
        $('#exampleModal').modal('hide');
        alert('Thêm mới thông tin học viên thành công!');
      }
    }, error => console.error(error));
  }

  updateUser(){
    var data4 = this.user;
    this.http.post('https://localhost:44309/' + 'api/User/update-user', data4).subscribe(result => {
      var res:any = result;
      if(res.success){
        this.user = res.data;
        this.searchUser(1);
        $('#exampleModal').modal('hide');
        alert('Cập nhật thông tin học viên thành công!');
      }
    }, error => console.error(error));
  }

}
