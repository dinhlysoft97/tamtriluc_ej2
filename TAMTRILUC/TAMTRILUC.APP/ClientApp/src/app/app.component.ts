//import { data } from './user-ej2/datasource';
import { Component, OnInit, Inject } from '@angular/core';
//import { data } from './datasource';
import { HttpClient } from '@angular/common/http';
import { DataManager, UrlAdaptor } from '@syncfusion/ej2-data';
import { PageSettingsModel, ToolbarItems, EditSettingsModel, IEditCell } from '@syncfusion/ej2-angular-grids';

@Component({
selector: 'app-root',
template: `<ejs-grid [dataSource]='data' [allowPaging]="true" [allowSorting]="true" [editSettings]='editSettings' [toolbar]='toolbar' height='400px'
            [allowFiltering]="true" [pageSettings]="pageSettings">
            <e-columns>
                <e-column field='userId' isPrimaryKey=true headerText='Mã Học Viên' width=80></e-column>
                <e-column field='userName' headerText='Tên Học Viên' width=130></e-column>
                <e-column field='gender' headerText='Giới Tính' width=80></e-column>
                <e-column field='age' headerText='Tuổi' width=80></e-column>
                <e-column field='phone' headerText='Điện Thoại' width=120></e-column>
                <e-column field='address' headerText='Địa Chỉ' width=140></e-column>
                <e-column field='createUserId' headerText='Người Phụ Trách' width=110></e-column>
                <e-column field='createDate' headerText='Ngày Đăng Kí' editType= 'datepickeredit' [edit]='dpParams' width=120></e-column>
            </e-columns>
            </ejs-grid>`
})

export class AppComponent implements OnInit {

  public data: DataManager;
  public pageSettings: PageSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public numericParams: IEditCell;
  public ddParams: IEditCell;
  public dpParams: IEditCell;
  public boolParams: IEditCell;

  public dataManager: DataManager = new DataManager({
    url: 'User/SearchUser',
    updateUrl: 'User/UpdateUser',
    insertUrl: 'User/InsertUser',
    removeUrl: 'User/DeleteUser',
    adaptor: new UrlAdaptor()
  });

  // Load dữ liệu gồm: url, request, response
  public request_search = {
    key :'',
    pageNumber: 1,
    pageSize:5,
  }
  public response_search: any = {
    data:[],
    pageSize:5,
    pageNumber:0,
    totalRecord:0,
    totalPages: 0,
  }
  public url_search = 'https://localhost:44309/' + 'api/User/search-user';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {}

  ngOnInit(): void {
    
    this.data = this.dataManager;
    this.pageSettings = { pageSize: 10 };
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];

    this.numericParams = { params: { decimals: 2, value: 5 } };
    this.ddParams = { params: { value: 'Germany' } };
    this.dpParams = { params: {value: new Date() } };
    this.boolParams = { params: {checked: true } };

    // this.http.post(this.url_search, this.request_search).toPromise().then(result => {
    //   this.response_search = result;
    //   this.data = this.response_search.data;
    //   //console.log(this.response_search.data);
    //   this.pageSettings = { pageSize: 10 };
    //   this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    //   this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
    // });
  }
}