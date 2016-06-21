function MainViewModel() {
    var self = this;

    self.lista = ko.observableArray();

    self.cadastro = ko.observable();
    self.cursos = ko.observableArray();
    self.alunos = ko.observableArray();
    self.turmas = ko.observableArray();
}

MainViewModel.prototype = {
    criar: function () {
        this.cadastro(new MatriculaViewModel());
        $('#modal_cadastro').modal('show');
    }
};

function MatriculaViewModel() {
    var self = this;

    self.Id = ko.observable();
    self.AlunoId = ko.observable();
    self.TurmaId = ko.observable();
    self.CursoId = ko.observable();
    self.Aluno = ko.observable();
    self.Turma = ko.observable();
    self.Curso = ko.observable();

    self.CursoId.subscribe(function () {
        if (!self.CursoId()) {
            mainVm.turmas([]);
            return;
        }

        $.getJSON('/Matricula/ListarTurmas', { cursoId: self.CursoId() }, function (data) {
            mainVm.turmas(data);
        });
    });
}

MatriculaViewModel.prototype = {
    salvar: function () {
        if (!$('#form_matricula').valid())
            return;

        if (!this.Id()) {
            $.postJSON('/Matricula/Create', ko.toJSON(this), function (retorno) {
                if (!retorno.Sucesso) {
                    alert('deu pau');
                    return;
                }
                atualizarGrid();
                alert('Matrícula registrada com sucesso!');
                $('#modal_cadastro').modal('hide');
            });
        } else {
            $.postJSON('/Matricula/Edit', ko.toJSON(this), function (retorno) {
                if (!retorno.Sucesso) {
                    alert('deu pau');
                    return;
                }
                atualizarGrid();
                alert('Matrícula atualizada com sucesso!');
                $('#modal_cadastro').modal('hide');
            });
        }
    },
    editar: function () {
        var cursoId = this.CursoId();
        this.CursoId(null);
        this.CursoId(cursoId);
        mainVm.cadastro(this);
        $('#modal_cadastro').modal('show');
    },
    excluir: function () {
        $.postJSON('/Matricula/Delete/' + this.Id(), function (retorno) {
            if (!retorno.Sucesso) {
                alert('deu pau');
                return;
            }
            atualizarGrid();
            alert('Matrícula excluída com sucesso!');
            $('#modal_cadastro').modal('hide');
        });
    }
};

var mainVm = new MainViewModel();
ko.applyBindings(mainVm, document.getElementById('corpo_matricula'));

var atualizarGrid = function () {
    $.getJSON('/Matricula/Listar', function (data) {
        mainVm.lista([]);
        data.forEach(function (d) {
            var maVm = new MatriculaViewModel();
            maVm.Id(d.Id);
            maVm.Aluno(d.Aluno);
            maVm.AlunoId(d.AlunoId);
            maVm.Curso(d.Curso);
            maVm.CursoId(d.CursoId);
            maVm.TurmaId(d.TurmaId);
            maVm.Turma(d.Turma);

            mainVm.lista.push(maVm);
        });
    });
};
atualizarGrid();

$.getJSON('/Matricula/ListarCursos', function (data) {
    mainVm.cursos(data);
});

$.getJSON('/Matricula/ListarAlunos', function (data) {
    mainVm.alunos(data);
});

jQuery.postJSON = function (url, data, callback) {
    if (typeof data == "function") {
        callback = data;
        data = "{}";
    }

    $.ajax({
        url: url,
        type: 'POST',
        cache: false,
        data: data,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: callback
    })
};