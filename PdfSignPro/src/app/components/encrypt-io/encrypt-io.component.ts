import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { SignIoComponent } from '../sign-io/sign-io.component';
import { saveAs } from 'file-saver';
@Component({
  selector: 'app-encrypt-io',
  templateUrl: './encrypt-io.component.html',
  styleUrls: ['./encrypt-io.component.css']
})
export class EncryptIoComponent implements OnInit {

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
      PassOwner: [""],
      PassUser: [""],
      Number: [""],
      CertUser: [],
      CertOwner: [],
      AllowEverything: false,
      AssembleDocument: false,
      CopyContents: false,
      ExtractContents: false,
      ModifyContents: false,
      PrintDocument: false,
      PrintFaithfulCopy: false,
    });
  }
  onFileChangeF2(event: any) {

    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.IOForm.patchValue({
        CertUser: file
      });
    }
  }
  onFileChangeF3(event: any) {

    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.IOForm.patchValue({
        CertOwner: file
      });
    }
  }
  // on Submit
  public onSubmit() {

    console.log("submited");
    let url = environment.url + "encrypt";

    let formData = new FormData();
    const formField = this.IOForm.value;
    formData.append('PdfFile', this.data.model.filePdf);

    Object.keys(formField).forEach((key) => {
      formData.append(key, formField[key]);
    });


    this.http.post(url, formData).subscribe((res: any) => {

      this.http.get(environment.urlServer + res.url, { responseType: "blob", headers: { 'Accept': 'application/pdf' } })
        .subscribe(blob => {
          saveAs(blob, 'pdf_encypted.pdf');
        });
    });
  }

}
