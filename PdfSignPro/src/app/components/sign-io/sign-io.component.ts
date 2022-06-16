import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-sign-io',
  templateUrl: './sign-io.component.html',
  styleUrls: ['./sign-io.component.css']
})
export class SignIoComponent implements OnInit {

  IOForm: FormGroup;
  dataModel: any;

  // ctor
  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    public dialogRef: MatDialogRef<SignIoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  // onInit
  ngOnInit() {
    this.bindingConfigValidation();
    console.log(this.data);
  }

  // config Form use add or update
  bindingConfigAddOrUpdate() {

  }

  // config input validation form
  bindingConfigValidation() {

    this.IOForm = this.formBuilder.group({
      name: [""],
      password: [""],
      reason: [""],
      location: [""],
      file2:[],
      file3:[],
    });
  }
  onFileChangeF1(event:any) {
  
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.IOForm.patchValue({
        file1: file
      });
    }
  }
  onFileChangeF2(event:any) {
  
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.IOForm.patchValue({
        file2: file
      });
    }
  }
  onFileChangeF3(event:any) {
  
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.IOForm.patchValue({
        file3: file
      });
    }
  }
  // on Submit
  public onSubmit() {

    console.log("submited");
    let url = environment.url + "sign?reason=" +  this.IOForm.get('reason')?.value + "&location=" +  this.IOForm.get('location')?.value
    + "&name=" +  this.IOForm.get('name')?.value + "&password=" +  this.IOForm.get('password')?.value;

    const formData = new FormData();
    formData.append('pdfFile', this.data.model.filePdf);
    formData.append('certFile', this.IOForm.get('file2')?.value);
    formData.append('handwrittingFile', this.IOForm.get('file3')?.value);

    this.http.post(url,formData).subscribe((res:any) => {
      window.open(environment.urlServer + res.url, "_blank");
    });


  }

  // close sidebar
  public closeIOSidebar() {
  }

}
