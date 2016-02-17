var articleApiUrl = '/api/Article/';
var commentApiUrl = '/api/Comment/';
var likeApiUrl = '/api/Like/';

function newsViewModel() {
    var self = this;
    self.articles = ko.observableArray([]);
    self.newArticle = ko.observable();
    self.mostLikedArticle = ko.observable();
    self.error = ko.observable();
    self.loadArticles = function () {
        //To load existing articles
        $.ajax({
            url: articleApiUrl+"Get",
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: 'GET'
        })
            .done(function (data) {
                if (data.Articles.length > 0) {
                    $.each(data.Articles, function(index,article)   
                    {
                        self.articles.push(new Article(article));

                    });

                }
            })
            .fail(function () {
               self.error('unable to load posts');
            });
    }

    self.addArticle = function () {
        var article = new Article();
        article.Content(self.newArticle());
        return $.ajax({
            url: articleApiUrl,
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: 'POST',
            data: ko.toJSON(article)
        })
       .done(function (result) {
           self.articles.splice(0, 0, new Article(result));
           self.newArticle('');
       })
       .fail(function () {
          self.error('unable to add post');
       });
    }
    self.loadArticles();
    return self;
};

ko.bindingHandlers.jqAutoresize = {
    init: function (element, valueAccessor, aBA, vm) {
        if (!$(element).hasClass('msgTextArea')) {
            $(element).css('height', '1em');
        }
        $(element).autosize();
    }
};

ko.applyBindings(new newsViewModel());

