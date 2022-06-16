import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignIoComponent } from './sign-io.component';

describe('SignIoComponent', () => {
  let component: SignIoComponent;
  let fixture: ComponentFixture<SignIoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignIoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SignIoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
