import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EditarLivroLivroComponent } from './editar-livro';

describe('EditarLivroLivroComponent', () => {
  let component: EditarLivroLivroComponent;
  let fixture: ComponentFixture<EditarLivroLivroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditarLivroLivroComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditarLivroLivroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
