import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatToolbarModule } from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import {MatButtonModule} from '@angular/material/button';
import { MatdialogService } from './helpers/mat-dialog.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { SignIoComponent } from './components/sign-io/sign-io.component';
import {MatDividerModule} from '@angular/material/divider';
import { MatFormFieldModule } from "@angular/material/form-field";
import {ReactiveFormsModule} from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { VerifyIoComponent } from './components/verify-io/verify-io.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { EncryptIoComponent } from './components/encrypt-io/encrypt-io.component';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSelectModule} from '@angular/material/select';
import { DecryptIoComponent } from './components/decrypt-io/decrypt-io.component';
import {MatListModule} from '@angular/material/list';
@NgModule({
  declarations: [
    AppComponent,
    SignIoComponent,
    VerifyIoComponent,
    EncryptIoComponent,
    DecryptIoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    PdfViewerModule,
    MatButtonModule,
    MatDialogModule,
    MatDividerModule,
    MatFormFieldModule,
    ReactiveFormsModule ,
    HttpClientModule,
    MatSnackBarModule,
    MatCheckboxModule,
    MatSelectModule,
    MatListModule
  ],
  providers: [
    MatdialogService
  ],
  entryComponents:[
    SignIoComponent,
    VerifyIoComponent,
    EncryptIoComponent,
    DecryptIoComponent],

  bootstrap: [AppComponent]
})
export class AppModule { }
